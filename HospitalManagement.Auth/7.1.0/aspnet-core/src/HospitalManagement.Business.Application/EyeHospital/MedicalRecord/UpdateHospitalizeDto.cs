using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class UpdateHospitalizeDto
    {
        public Guid Id { get; set; }
        public bool IsHospitalize { get; set; }
        public DateTime FromDateHospitalize { get; set; }
        public DateTime ToDateHospitalize { get; set; }
    }
}
