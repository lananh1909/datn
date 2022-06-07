using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.EyeHospital
{
    public class PatientAppointmentDto
    {
        public int BookFor { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Guid ServiceId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string DescribeSymptom { get; set; }
    }
}
