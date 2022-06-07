using System.Threading.Tasks;
using HospitalManagement.Business.Models.TokenAuth;
using HospitalManagement.Business.Web.Controllers;
using Shouldly;
using Xunit;

namespace HospitalManagement.Business.Web.Tests.Controllers
{
    public class HomeController_Tests: BusinessWebTestBase
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