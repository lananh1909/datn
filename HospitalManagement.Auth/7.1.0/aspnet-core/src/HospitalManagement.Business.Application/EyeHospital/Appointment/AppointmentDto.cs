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
    public class AppointmentDto : FullAuditedEntityDto<Guid>
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int Status { get; set; }
        public Guid DoctorId { get; set; }
        public Employee Doctor { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
        /// <summary>
        /// Mô tả triệu chứng
        /// </summary>
        public string DescribeSymptom { get; set; }
    }
}
