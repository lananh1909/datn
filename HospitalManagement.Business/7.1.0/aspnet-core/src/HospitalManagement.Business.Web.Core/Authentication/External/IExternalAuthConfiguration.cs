using System.Collections.Generic;

namespace HospitalManagement.Business.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
