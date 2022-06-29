using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business
{
    public class ErrorConstants
    {
        public const string BusinessErrorCode = "503";
        public const string BadRequestErrorCode = "404";


        public const string BusinessErrorMessage = "Có lỗi xảy ra khi gọi service";
        public const string EmployeeCodeExists = "Mã nhân viên đã tồn tại";
        public const string UserExistsMessage = "Đã tồn tại nhân viên với người dùng này";
        public const string BadRequestErrorMessage = "Không tìm thấy tài nguyên yêu cầu";
    }
}
