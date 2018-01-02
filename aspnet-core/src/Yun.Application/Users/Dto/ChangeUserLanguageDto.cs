using System.ComponentModel.DataAnnotations;

namespace Yun.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}