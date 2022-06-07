using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Auth.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}