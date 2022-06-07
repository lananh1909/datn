using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;

namespace HospitalManagement.Business
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class BusinessAppServiceBase : ApplicationService
    {
    }
}
