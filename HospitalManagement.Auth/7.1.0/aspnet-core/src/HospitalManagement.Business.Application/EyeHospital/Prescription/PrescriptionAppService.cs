using Abp.Application.Services;
using Abp.Domain.Repositories;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.Repositories;
using HospitalManagement.Business.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace HospitalManagement.Business.EyeHospital.HospitalTracking
{
    public class PrescriptionAppService : AsyncCrudAppService<Prescription, PrescriptionDto, Guid>
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IUserInfo _userInfo;
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IPrescriptionMedicineRepository _prescriptionMedicineRepository;
        public PrescriptionAppService(IPrescriptionRepository repository, IUserInfo userInfo, IPrescriptionMedicineRepository prescriptionMedicineRepository, IEmployeeAppService employeeAppService) : base(repository)
        {
            _prescriptionRepository = repository;
            _userInfo = userInfo;
            _prescriptionMedicineRepository = prescriptionMedicineRepository;
            _employeeAppService = employeeAppService;
        }

        public async Task<List<PrescriptionDto>> GetByMedicalRecord(Guid medicalRecordId)
        {
            var prescriptions = _prescriptionRepository.GetAllIncluding(p => p.Employee).Include(p => p.PrescriptionMedicines.Where(x => x.IsDeleted == false)).ThenInclude(p => p.Medicine).Where(p => p.MedicalRecordId.Equals(medicalRecordId)).Where(p => p.IsDeleted == false).OrderBy(p => p.CreationTime).ThenBy(p => p.LastModificationTime).ToList();
            return ObjectMapper.Map<List<PrescriptionDto>>(prescriptions);
        }

        public async Task<bool> CreatePrescription(PrescriptionAddAndUpdateDto input)
        {
            var doctor = await _employeeAppService.GetByUserId(_userInfo.UserId);
            if(doctor == null)
            {
                throw new UnauthorizedAccessException();
            }
            var prescription = ObjectMapper.Map<Prescription>(input);
            prescription.CreatedBy = doctor.Id;
            prescription = await _prescriptionRepository.InsertAsync(prescription);
            foreach (var medicine in input.PrescriptionMedicines) 
            {
                var medicineDto = new PrescriptionMedicine()
                {
                    Instruction = medicine.Instruction,
                    MedicineId = medicine.MedicineId,
                    PrescriptionId = prescription.Id,
                    Quantity = medicine.Quantity,
                };
                await _prescriptionMedicineRepository.InsertAsync(medicineDto);
            }
            return true;
        }

        public async Task<bool> UpdatePrescription(PrescriptionAddAndUpdateDto input)
        {
            var doctor = await _employeeAppService.GetByUserId(_userInfo.UserId);
            if (doctor == null)
            {
                throw new UnauthorizedAccessException();
            }
            var prescriptions = await _prescriptionRepository.GetAsync(input.Id);
            if(prescriptions == null)
            {
                throw new BusinessException(ErrorConstants.BadRequestErrorCode, ErrorConstants.BadRequestErrorMessage);
            }
            prescriptions.CreatedBy = doctor.Id;
            await _prescriptionRepository.UpdateAsync(prescriptions);
            var medicines = _prescriptionMedicineRepository.GetAll().Where(p => p.PrescriptionId.Equals(input.Id)).ToList();
            foreach (var medicine in medicines)
            {
                await _prescriptionMedicineRepository.DeleteAsync(medicine);
            }
            foreach (var medicine in input.PrescriptionMedicines)
            {
                var medicineDto = new PrescriptionMedicine()
                {
                    Instruction = medicine.Instruction,
                    MedicineId = medicine.MedicineId,
                    PrescriptionId = input.Id,
                    Quantity = medicine.Quantity,
                };
                await _prescriptionMedicineRepository.InsertAsync(medicineDto);
            }
            return true;
        }
    }
}