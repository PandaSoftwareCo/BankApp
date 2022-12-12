using BankApp.Application.DTOs.User;
using BankApp.Core.Domain.Entities;

namespace BankApp.Application.Common.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        User GetById(int id);
        void AddUser(User user, string password);
    }
}
