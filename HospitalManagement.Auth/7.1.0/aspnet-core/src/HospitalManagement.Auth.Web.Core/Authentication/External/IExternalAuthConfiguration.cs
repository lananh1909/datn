﻿using System.Collections.Generic;

namespace HospitalManagement.Auth.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
