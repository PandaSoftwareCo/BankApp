using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BankApp.Application.DTOs.User
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(BankApp.Core.Domain.Entities.User user, string token)
        {
            Id = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Token = token;
        }
    }
}
