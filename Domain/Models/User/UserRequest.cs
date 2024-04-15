using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Domain.Models.User
{
    public class UserRequest
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string UserPassword { get; set; }
    }
}
