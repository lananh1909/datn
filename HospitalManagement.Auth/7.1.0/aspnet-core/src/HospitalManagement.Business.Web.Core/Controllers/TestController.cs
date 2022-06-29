using HospitalManagement.Business.EyeHospital;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Controllers
{
    [AllowAnonymous]
    [Route("api/services/app/[controller]")]
    public class TestController : BusinessControllerBase
    {
        private readonly ITestAppService _testAppService;

        public TestController(ITestAppService testAppService)
        {
            _testAppService = testAppService;
        }

        [HttpPut("UpdateTest")]
        public async Task<IActionResult> UpdateTest([FromForm] UpdateTestDto updateTestDto)
        {
            return Ok(await _testAppService.UpdateTestService(updateTestDto));
        }
    }
}
