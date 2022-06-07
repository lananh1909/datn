using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Business.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}