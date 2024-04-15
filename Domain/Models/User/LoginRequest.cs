using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Domain.Models.User
{
    public class LoginRequest
    {
        [Required]
        public string LoginEmail { get; set; }

        [Required]
        public string LoginPassword { get; set; }
    }
}
