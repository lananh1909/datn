using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Identity
{
    public class AuthResponse<T>
    {
        public T Result { get; set; }
    }
}
