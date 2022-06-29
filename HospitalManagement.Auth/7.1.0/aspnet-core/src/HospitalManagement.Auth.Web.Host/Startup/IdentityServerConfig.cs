using IdentityServer4.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagement.Auth.Web.Host.Startup
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope> {
                new ApiScope("default-api")
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("default-api", "Default (all) API"),
                new ApiResource("api", "All API"),
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResources.Phone()
        };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials.Union(GrantTypes.ResourceOwnerPassword).ToList(),
                    AllowedScopes = {"default-api"},
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                },
                new Client
                {
                    ClientId = "business-client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"default-api"},
                    ClientSecrets =
                    {
                        new Secret("12345678@Abc".Sha256()),
                    }
                }
            };
        }
    }
}
