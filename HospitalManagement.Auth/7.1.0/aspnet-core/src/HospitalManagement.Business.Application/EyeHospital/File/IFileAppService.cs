using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital.File
{
    public interface IFileAppService
    {
        Task<byte[]> GetObject(string objectName, string fileName);
        string GetMimeType(string extension);
        Task<string> PutObject(string fileName, Stream data);
    }
}
