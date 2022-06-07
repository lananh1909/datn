using Abp.AutoMapper;
using HospitalManagement.Auth.Authentication.External;

namespace HospitalManagement.Auth.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
