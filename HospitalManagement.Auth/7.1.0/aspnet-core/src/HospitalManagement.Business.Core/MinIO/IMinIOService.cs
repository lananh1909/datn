using Minio.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.MinIO
{
    public interface IMinIOService
    {
        Task<byte[]> GetObjectAsync(string objectName, string fileName);
        Task<bool> PutObject(string objectName, Stream data);
    }
}
