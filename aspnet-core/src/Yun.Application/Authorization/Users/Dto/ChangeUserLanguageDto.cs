using System.ComponentModel.DataAnnotations;

namespace Yun.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
