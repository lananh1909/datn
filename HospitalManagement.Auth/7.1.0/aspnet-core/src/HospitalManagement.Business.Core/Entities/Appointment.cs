using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    [Table("appointment")]
    public class Appointment : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Thời gian hẹn
        /// </summary>
        public DateTime Date { get; set; }
        public string Time { get; set; }
        /// <summary>
        /// Trạng thái 1: New, 2: Đã xác nhận, 3: Đã hủy
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Bác sĩ phụ trách
        /// </summary>
        public Guid DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Employee Doctor { get; set; }
        /// <summary>
        /// Bệnh nhân
        /// </summary>
        public Guid PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        /// <summary>
        /// Dịch vụ đặt lịch
        /// </summary>
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        public Guid ServiceId { get; set; }
        /// <summary>
        /// Mô tả triệu chứng
        /// </summary>
        public string DescribeSymptom { get; set; }
    }
}
