using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Entities
{
    [Table("patient")]
    public class Patient: FullAuditedEntity<Guid>
    {
        [Required]
        public string PatientCode { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Sex { get; set; }
        public string Address { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Tiền sử dị ứng
        /// </summary>
        public string HistoryOffAllergy { get; set; }
        /// <summary>
        /// Bệnh nền
        /// </summary>
        public string BackgroundDisease { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// Là hồ sơ của cá nhân hay của người thân
        /// </summary>
        public bool IsSelf { get; set; } = true;
        /// <summary>
        /// Độ cầu mắt phải
        /// </summary>
        public float RightEsphere { get; set; }
        /// <summary>
        /// Độ trụ mắt phải
        /// </summary>
        public float RightCylinder { get; set; }
        /// <summary>
        /// Thị lực mắt phải
        /// </summary>
        public string RightVisualAcuity { get; set; }
        /// <summary>
        /// Độ cầu mắt trái
        /// </summary>
        public float LeftEsphere { get; set; }
        /// <summary>
        /// Độ trụ mắt trái
        /// </summary>
        public float LeftCylinder { get; set; }
        /// <summary>
        /// Thị lực mắt trái
        /// </summary>
        public string LeftVisualAcuity { get; set; }
        /// <summary>
        /// Độ kính mắt trái
        /// </summary>
        public float LeftGlass { get; set; }
        /// <summary>
        /// Độ kính mắt phải
        /// </summary>
        public float RightGlass { get; set; }
    }
}
