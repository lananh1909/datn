using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using HospitalManagement.Business.Configuration;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Identity;
using HospitalManagement.Business.Repositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace HospitalManagement.Business.EyeHospital
{
    public class EmployeeAppService : AsyncCrudAppService<Employee, EmployeeDto, Guid, EmployeePagedAndSortDto, EmployeeAddAndUpdateDto>, IEmployeeAppService
    {
        private readonly AuthenticationServerConfig _authConfig;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IIdentityUserHelper _identityUserHelper;
        public EmployeeAppService(IEmployeeRepository employeeRepository, IOptions<AuthenticationServerConfig> option, IIdentityUserHelper identityUserHelper) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _authConfig = option.Value;
            _identityUserHelper = identityUserHelper;
        }
        [AbpAuthorize("Pages.Employees.Delete")]
        public async Task DeleteManyAsync(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var employee = await this.GetAsync(new EntityDto<Guid>(id));
                await this.DeleteAsync(employee);
            }
        }

        protected override IQueryable<Employee> CreateFilteredQuery(EmployeePagedAndSortDto input)
        {
            return Repository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.PhoneNumber.Contains(input.Keyword) || x.Name.Contains(input.Keyword) || x.EmployeeCode.Contains(input.Keyword)).WhereIf(input.JobTitle != 0, x => ((int)x.JobTitle == input.JobTitle)).Where(p => p.IsDeleted == false);
        }

        protected override IQueryable<Employee> ApplySorting(IQueryable<Employee> query, EmployeePagedAndSortDto input)
        {
            var sortBy = "EmployeeCode";
            if (!string.IsNullOrEmpty(input.SortBy))
            {
                sortBy = input.SortBy + " " + input.SortType;
            }
            input.Sorting = sortBy;
            return base.ApplySorting(query, input);
        }

        [AbpAuthorize("Pages.Employees.Create")]
        public async Task<string> GetNewEmployeeCode()
        {
            return await _employeeRepository.GetNewEmployeeCode();
        }

        [AbpAuthorize("Pages.Employees.Create")]
        public override async Task<EmployeeDto> CreateAsync(EmployeeAddAndUpdateDto input)
        {
            var existsEmployeeCode = _employeeRepository.GetAll().Where(e => e.EmployeeCode == input.EmployeeCode).FirstOrDefault();
            if (existsEmployeeCode != null)
            {
                throw new BusinessException(ErrorConstants.BusinessErrorCode, ErrorConstants.EmployeeCodeExists);
            }
            var existsEmployee = _employeeRepository.GetAll().Where(e => e.UserId == input.UserId).FirstOrDefault();
            if (existsEmployee != null)
            {
                throw new BusinessException(ErrorConstants.BusinessErrorCode, ErrorConstants.UserExistsMessage);
            }
            var existsUser = _identityUserHelper.GetUserById(input.UserId);
            if (existsUser == null)
            {
                throw new BusinessException(ErrorConstants.BusinessErrorCode, ErrorConstants.BusinessErrorMessage);
            }
            return await base.CreateAsync(input);
        }
        [AbpAuthorize("Pages.Employees.Delete")]
        public override Task DeleteAsync(EntityDto<Guid> input)
        {
            return base.DeleteAsync(input);
        }
        
        [AbpAuthorize("Pages.Employees.View")]
        public override Task<PagedResultDto<EmployeeDto>> GetAllAsync(EmployeePagedAndSortDto input)
        {
            return base.GetAllAsync(input);
        }
        [AbpAuthorize("Pages.Employees.View")]
        public override Task<EmployeeDto> GetAsync(EntityDto<Guid> input)
        {
            return base.GetAsync(input);
        }
        [AbpAuthorize("Pages.Employees.Update")]
        public override async Task<EmployeeDto> UpdateAsync(EmployeeAddAndUpdateDto input)
        {
            var existsEmployeeCode = _employeeRepository.GetAll().Where(e => e.EmployeeCode == input.EmployeeCode && e.Id != input.Id).FirstOrDefault();
            if (existsEmployeeCode != null)
            {
                throw new BusinessException(ErrorConstants.BusinessErrorCode, ErrorConstants.EmployeeCodeExists);
            }
            var token = await IdentityCredential.GetAccessToken();
            var existsEmployee = _employeeRepository.GetAll().Where(e => e.UserId == input.UserId && e.Id != input.Id).FirstOrDefault();
            if (existsEmployee != null)
            {
                throw new BusinessException(ErrorConstants.BusinessErrorCode, ErrorConstants.UserExistsMessage);
            }
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync(_authConfig.BaseUrl + _authConfig.GetUserById + "?id=" + input.UserId);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new BusinessException(ErrorConstants.BusinessErrorCode, ErrorConstants.BusinessErrorMessage);
                } 
            }
            return await base.UpdateAsync(input);
        }
        [AbpAuthorize("Pages.Employees.View")]
        public async Task<List<EmployeeDto>> GetDoctor()
        {
            var result = _employeeRepository.GetAll().Where(d => d.JobTitle == Enums.EmployeeJobTitle.DOCTOR).Where(p => p.IsDeleted == false);
            return ObjectMapper.Map<List<EmployeeDto>>(result);
        }
        [AbpAuthorize("Pages.Employees.View")]
        public async Task<List<EmployeeDto>> GetMedicalEmployee()
        {
            var result = _employeeRepository.GetAll().Where(d => d.JobTitle == Enums.EmployeeJobTitle.MEDICALEMPLOYEE).Where(p => p.IsDeleted == false);
            return ObjectMapper.Map<List<EmployeeDto>>(result);
        }
        public async Task<EmployeeDto> GetByUserId(int userId)
        {
            var employee = _employeeRepository.GetAll().Where(p => p.UserId == userId).FirstOrDefault();
            return ObjectMapper.Map<EmployeeDto>(employee);
        }

    }
}
