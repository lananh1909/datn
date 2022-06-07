﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.User
{
    public interface IUserInfo
    {
        public string Token { get; }
        public int UserId { get; }
        public string Name { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Role { get; }
    }
}