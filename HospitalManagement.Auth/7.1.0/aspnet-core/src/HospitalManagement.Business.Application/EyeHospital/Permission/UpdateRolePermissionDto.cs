using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class UpdateRolePermissionDto
    {
        public string Role { get; set; }
        public List<string> Permissions { get; set; }
    }
}
