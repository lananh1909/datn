using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Identity
{
    public interface IIdentityUserHelper
    {
        Task<UserResponse> GetUserById(int id);
    }
}
