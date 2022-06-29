using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.EyeHospital.File;
using HospitalManagement.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace HospitalManagement.Business.EyeHospital.HospitalTracking
{
    public class SurgeryAppService : AsyncCrudAppService<Surgery, SurgeryDto, Guid, SurgeryPagedAndSortDto>, ISurgeryAppService
    {
        private readonly ISurgeryRepository _repository;
        private readonly ISurgeryDoctorRepository _surgerydoctorRepository;
        private readonly IFileAppService _fileAppService;
        public SurgeryAppService(ISurgeryRepository repository, ISurgeryDoctorRepository surgerydoctorRepository, IFileAppService fileAppService) : base(repository)
        {
            _repository = repository;
            _surgerydoctorRepository = surgerydoctorRepository;
            _fileAppService = fileAppService;
        }

        public async Task<List<SurgeryDto>> GetByMedicalRecordId(Guid id)
        {
            var surgeries = _repository.GetAllIncluding(p => p.SurgeryType).Include(p => p.SurgeryDoctors).ThenInclude(p => p.Doctor).Where(p => p.MedicalRecordId.Equals(id)).Where(p => p.IsDeleted == false).OrderBy(p => p.CreationTime).ThenBy(p => p.LastModificationTime).ToList();
            return ObjectMapper.Map<List<SurgeryDto>>(surgeries);
        }

        public async Task<bool> UpdateCancelSurgery(Guid id)
        {
            var surgery = await _repository.GetAsync(id);
            if(surgery == null)
            {
                throw new BusinessException(ErrorConstants.BadRequestErrorCode, ErrorConstants.BadRequestErrorMessage);
            }
            surgery.Status = 2;
            await _repository.UpdateAsync(surgery);
            return true;
        }

        public async Task<bool> CreateNewSurgery(SurgeryAddAndUpdateDto input)
        {
            try
            {
                var surgery = await _repository.InsertAsync(ObjectMapper.Map<Surgery>(input));
                foreach (var doctor in input.Doctors)
                {
                    var surgeryDoctor = new SurgeryDoctor()
                    {
                        SurgeryId = surgery.Id,
                        DoctorId = doctor.DoctorId,
                        Role = doctor.Role
                    };
                    await _surgerydoctorRepository.InsertAsync(surgeryDoctor);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ErrorConstants.BusinessErrorCode, ErrorConstants.BusinessErrorMessage);
            }
        }

        public async Task<bool> UpdateSurgery(SurgeryUpdateDto input)
        {
            try
            {
                var oldSurgery = _repository.GetAll().Include(p => p.SurgeryDoctors).ThenInclude(p => p.Doctor).Where(p => p.Id == input.Id).FirstOrDefault();
                if(oldSurgery == null)
                {
                    throw new BusinessException(ErrorConstants.BadRequestErrorCode, ErrorConstants.BadRequestErrorMessage);
                }
                foreach (var doctor in oldSurgery.SurgeryDoctors)
                {
                    await _surgerydoctorRepository.DeleteAsync(doctor.Id);
                }
                foreach (var doctor in input.SurgeryDoctors)
                {
                    var tmp = JsonConvert.DeserializeObject<DoctorSurgeryDto>(doctor);
                    var surgeryDoctor = new SurgeryDoctor()
                    {
                        SurgeryId = oldSurgery.Id,
                        DoctorId = tmp.DoctorId,
                        Role = tmp.Role
                    };
                    await _surgerydoctorRepository.InsertAsync(surgeryDoctor);
                }
                ObjectMapper.Map<SurgeryUpdateDto, Surgery>(input, oldSurgery);
                if (input.AttackFile != null)
                {
                    using (MemoryStream strem = new MemoryStream())
                    {
                        input.AttackFile.CopyTo(strem);
                        var url = await _fileAppService.PutObject(input.AttackFile.FileName, strem);
                        oldSurgery.AttackUrl = url;
                    };
                }                
                oldSurgery = await _repository.UpdateAsync(oldSurgery);
                
                return true;
            }
            catch (Exception ex)
            {
                throw new BusinessException(ErrorConstants.BusinessErrorCode, ErrorConstants.BusinessErrorMessage);
            }
        }
        protected override IQueryable<Surgery> CreateFilteredQuery(SurgeryPagedAndSortDto input)
        {
            return _repository.GetAllIncluding(p => p.SurgeryType, p => p.MedicalRecord, p => p.MedicalRecord.Patient).Include(p => p.SurgeryDoctors.Where(x => x.IsDeleted == false)).ThenInclude(p => p.Doctor)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.MedicalRecord.Patient.PatientCode.Contains(input.Keyword) || x.MedicalRecord.Patient.Name.Contains(input.Keyword)).WhereIf(input.SurgeryTypeId != null, x => x.SurgeryTypeId.Equals(input.SurgeryTypeId)).WhereIf(input.Status != null, x => x.Status == input.Status).Where(x => x.IsDeleted == false);
        }

        public async Task DeleteManyAsync(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var surgery = await this.GetAsync(new EntityDto<Guid>(id));
                await this.DeleteAsync(surgery);
            }
        }
    }
}
