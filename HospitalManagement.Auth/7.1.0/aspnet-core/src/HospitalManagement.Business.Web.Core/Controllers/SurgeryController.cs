using HospitalManagement.Business.EyeHospital;
using HospitalManagement.Business.EyeHospital.File;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Controllers
{
    [AllowAnonymous]
    [Route("api/services/app/[controller]")]
    public class SurgeryController : BusinessControllerBase
    {
        private readonly ISurgeryAppService _surgeryAppService;

        public SurgeryController(ISurgeryAppService surgeryAppService)
        {
            _surgeryAppService = surgeryAppService;
        }
        [HttpPut("v1/update")]
        public async Task<IActionResult> UpdateSurgery([FromForm] SurgeryUpdateDto input) 
        {
            return Ok(await _surgeryAppService.UpdateSurgery(input));
        }
    }
}
