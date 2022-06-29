using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static IdentityModel.OidcConstants;

namespace HospitalManagement.Business.Identity
{
    public class IdentityCredential
    {
        public static async Task<string> GetAccessToken()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:44311");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "business-client",
                ClientSecret = "12345678@Abc",
                Scope = "default-api",
                GrantType = GrantTypes.ClientCredentials
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }
            return tokenResponse.AccessToken;
        }
    }
}
