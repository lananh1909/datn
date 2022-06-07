using Abp.Application.Services.Dto;
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
    [Route("api/v1/[controller]")]
    public class PatientController : BusinessControllerBase
    {
        private readonly IPatientAppService _patientAppService;

        public PatientController(IPatientAppService patientAppService)
        {
            _patientAppService = patientAppService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll(PatientPagedAndSortDto input)
        //{
        //    return Ok(await _patientAppService.GetAllAsync(input));
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateEntity([FromBody] PatientAddAndUpdateDto input)
        //{
        //    return Ok(await _patientAppService.CreateAsync(input));
        //}
        //[HttpPut]
        //public async Task<IActionResult> UpdateEntity([FromBody] PatientAddAndUpdateDto input)
        //{
        //    return Ok(await _patientAppService.UpdateAsync(input));
        //}
        //[HttpDelete]
        //public async Task<IActionResult> DeleteEntity(Guid id)
        //{
        //    try
        //    {
        //        var deletedEntity = new EntityDto<Guid>(id);
        //        await _patientAppService.DeleteAsync(deletedEntity);
        //        return Ok();
        //    } catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }
        //}
    }
}
