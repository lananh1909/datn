using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HospitalManagement.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    [AutoMap(typeof(Appointment))]
    public class AppointmentAddAndUpdateDto : EntityDto<Guid>
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int Status { get; set; } = 1;
        public Guid? DoctorId { get; set; }
        [Required]
        public Guid PatientId { get; set; }

        public Guid ServiceId { get; set; }
        /// <summary>
        /// Mô tả triệu chứng
        /// </summary>
        public string DescribeSymptom { get; set; }
    }
}
