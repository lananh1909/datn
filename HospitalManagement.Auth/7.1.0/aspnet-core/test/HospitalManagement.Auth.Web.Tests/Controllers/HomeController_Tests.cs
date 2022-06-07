using System.Threading.Tasks;
using HospitalManagement.Auth.Models.TokenAuth;
using HospitalManagement.Auth.Web.Controllers;
using Shouldly;
using Xunit;

namespace HospitalManagement.Auth.Web.Tests.Controllers
{
    public class HomeController_Tests: AuthWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}