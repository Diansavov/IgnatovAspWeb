

using System.ComponentModel.DataAnnotations;

namespace TestIgnatov.Models.ViewModels.User
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}