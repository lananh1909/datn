using Abp.Dependency;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.MinIO
{
    public class MinIOService : IMinIOService, ITransientDependency
    {
        private readonly ILogger<MinIOService> _logger;
        private readonly AmazonS3Client client;
        private readonly MinIOOption _options;

        public MinIOService(ILogger<MinIOService> logger, IOptions<MinIOOption> options)
        {
            _logger = logger;
            _options = options.Value;
            var config = new AmazonS3Config()
            {
                RegionEndpoint = RegionEndpoint.USEast1,
                AuthenticationRegion = RegionEndpoint.USEast1.SystemName,
                ServiceURL = _options.endpoint,
                ForcePathStyle = true
            };
            client = new AmazonS3Client(_options.accessKey, _options.secretKey, config);
            //client = new MinioClient()
            //                        .WithEndpoint(_options.endpoint)
            //                        .WithCredentials(_options.accessKey, _options.secretKey)
            //                        //.WithSSL()
            //                        .Build();
        }

        public async Task<byte[]> GetObjectAsync(string objectName, string fileName)
        {
            try
            {
                var request = new GetObjectRequest()
                {
                    BucketName = _options.bucketName,
                    Key = objectName
                };
                var response = await client.GetObjectAsync(request);
                var result = ReadObjectStream(response.ResponseStream);
                return result;
                //var args = new GetObjectArgs()
                //.WithBucket(_options.bucketName)
                //.WithObject(objectName)
                //.WithFile(fileName)
                //.WithCallbackStream((stream) =>
                //{

                //});
                //await client.GetObjectAsync(args);
                //return ms.ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<bool> PutObject(string objectName, Stream data)
        {
            try
            {
                var request = new PutObjectRequest()
                {
                    BucketName = _options.bucketName,
                    Key = objectName,
                    InputStream = data
                };
                await client.PutObjectAsync(request);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Minio:PutObject ", ex);
                return false;
            }
        }

        public byte[] ReadObjectStream(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
