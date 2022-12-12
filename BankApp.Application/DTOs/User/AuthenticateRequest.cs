using System.ComponentModel.DataAnnotations;

namespace BankApp.Application.DTOs.User
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
