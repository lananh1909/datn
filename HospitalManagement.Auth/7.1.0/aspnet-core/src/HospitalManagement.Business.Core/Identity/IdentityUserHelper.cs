using HospitalManagement.Business.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Abp.Dependency;

namespace HospitalManagement.Business.Identity
{
    public class IdentityUserHelper : IIdentityUserHelper, ITransientDependency 
    {
        private readonly AuthenticationServerConfig _authConfig;

        public IdentityUserHelper(IOptions<AuthenticationServerConfig> authConfig)
        {
            _authConfig = authConfig.Value;
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            var token = await IdentityCredential.GetAccessToken();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var response = await client.GetAsync(_authConfig.BaseUrl + _authConfig.GetUserById + "?id=" + id);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var user = JsonConvert.DeserializeObject<AuthResponse<UserResponse>>(await response.Content.ReadAsStringAsync());
                    return user.Result;
                }
            }
            return null;
        }
    }
}
