using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.MinIO
{
    public class MinIOOption
    {
        public string endpoint { get; set; }
        public string accessKey { get; set; }
        public string secretKey { get; set; }
        public string bucketName { get; set; }
        public string BasePathUrl { get; set; }
    }
}
