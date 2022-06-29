using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class UpdateTestDto
    {
        public Guid Id { get; set; }
        public string Result { get; set; }
        public IFormFile AttackFile { get; set; }
        public Guid? PerformedBy { get; set; }
        public int Status { get; set; }
    }
}
