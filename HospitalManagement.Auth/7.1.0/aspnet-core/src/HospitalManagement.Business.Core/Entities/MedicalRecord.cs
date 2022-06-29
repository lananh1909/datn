using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    [Table("medical_record")]
    public class MedicalRecord: FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Chuẩn đoán 
        /// </summary>
        public string Diagnosis { get; set; }
        /// <summary>
        /// Triệu chứng
        /// </summary>
        public string Symptom { get; set; }
        /// <summary>
        /// Phương pháp điều trị
        /// </summary>
        public string StreatmentMethod { get; set; }
        /// <summary>
        /// Nguyên nhân
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// Ngày bắt đầu
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Ngày kết thúc
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Tạo bởi
        /// </summary>
        public Guid CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public Employee Employee { get; set; }
        /// <summary>
        /// Thông tin bệnh nhân
        /// </summary>
        public Guid PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public Appointment Appointment { get; set; }
        [ForeignKey("AppointmentId")]
        public Guid? AppointmentId { get; set; }
        /// <summary>
        /// Có phải điều trị nội trú hay không
        /// </summary>
        public bool IsHospitalize { get; set; } = false;
        /// <summary>
        /// ĐIều trị nội trú từ ngày
        /// </summary>
        public DateTime? FromDateHospitalize { get; set; }
        /// <summary>
        /// Đến ngày
        /// </summary>
        public DateTime? ToDateHospitalize { get; set; }

    }
}
