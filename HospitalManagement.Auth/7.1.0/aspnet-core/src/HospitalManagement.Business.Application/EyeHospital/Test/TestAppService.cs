using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.EyeHospital.File;
using HospitalManagement.Business.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace HospitalManagement.Business.EyeHospital.HospitalTracking
{
    public class TestAppService : AsyncCrudAppService<Test, TestDto, Guid, TestPagedAndSortDto>, ITestAppService
    {
        private readonly ITestRepository _testRepository;
        private readonly IFileAppService _fileAppService;
        public TestAppService(ITestRepository repository, IFileAppService fileAppService) : base(repository)
        {
            _testRepository = repository;
            _fileAppService = fileAppService;
        }

        public async Task<List<TestDto>> GetByMedicalRecordId(Guid id)
        {
            var tests = _testRepository.GetAllIncluding(p => p.TestType, p => p.Employee).Where(p => p.IsDeleted == false).Where(p => p.MedicalRecordId.Equals(id)).OrderBy(p => p.CreationTime).ThenBy(p => p.LastModificationTime).ToList();
            return ObjectMapper.Map<List<TestDto>>(tests);
        }

        protected override IQueryable<Test> CreateFilteredQuery(TestPagedAndSortDto input)
        {
            return _testRepository.GetAllIncluding(p => p.TestType, p => p.Employee, p => p.MedicalRecord, p => p.MedicalRecord.Patient)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.MedicalRecord.Patient.PatientCode.Contains(input.Keyword) || x.MedicalRecord.Patient.Name.Contains(input.Keyword)).WhereIf(input.TestTypeId != null, x => x.TestTypeId.Equals(input.TestTypeId)).WhereIf(input.Status != null, x => x.Status == input.Status).Where(x => x.IsDeleted == false);
        }

        public async Task DeleteManyAsync(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var test = await this.GetAsync(new EntityDto<Guid>(id));
                await this.DeleteAsync(test);
            }
        }

        public async Task<bool> UpdateTestService(UpdateTestDto input)
        {
            var test = await _testRepository.GetAsync(input.Id);
            if(test == null)
            {
                throw new BusinessException(ErrorConstants.BadRequestErrorCode, ErrorConstants.BadRequestErrorMessage);
            }
            ObjectMapper.Map<UpdateTestDto, Test>(input, test);
            if (input.AttackFile != null)
            {
                using (MemoryStream strem = new MemoryStream())
                {
                    input.AttackFile.CopyTo(strem);
                    var url = await _fileAppService.PutObject(input.AttackFile.FileName, strem);
                    test.FileUrl = url;
                };
            }
            await _testRepository.UpdateAsync(test);
            return true;
        } 
        public async Task<bool> UpdateCancelTest(Guid testId)
        {
            var test = await _testRepository.GetAsync(testId);
            if(test == null)
            {
                throw new BusinessException(ErrorConstants.BadRequestErrorCode, ErrorConstants.BadRequestErrorMessage);
            }
            test.Status = 2;
            await _testRepository.UpdateAsync(test);
            return true;
        }
    }
}
