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
    [Route("api/v1/[controller]")]
    public class FileController : BusinessControllerBase
    {
        private readonly IFileAppService _fileAppService;

        public FileController(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFile(string fileName)
        {
            var fileContent = await _fileAppService.GetObject(fileName, fileName);
            var contentType = _fileAppService.GetMimeType(fileName);
            return File(fileContent, contentType);
        }

        [HttpPost]
        public async Task<IActionResult> PutObject(IFormFile file) 
        {
            using(MemoryStream strem = new MemoryStream())
            {
                file.CopyTo(strem);
                return Ok(await _fileAppService.PutObject(file.FileName, strem));
            }
            
        }
    }
}
