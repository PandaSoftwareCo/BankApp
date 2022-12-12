using BankApp.Application.Common.Interfaces;
using BankApp.Application.DTOs.User;
using BankApp.Core.Domain.Entities;
using BankApp.Data.Contexts;
using BankApp.Identity.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly BankContext _context;
        private readonly AuthSettings _authSettings;

        public UserService(BankContext context, AuthSettings authSettings)
        {
            _context = context;
            _authSettings = authSettings;
        }

        public void AddUser(User user, string password)
        {
            //string data = password; "P@ssw0rd";
            //user.Salt = RandomNumberGenerator.GetBytes(32);
            //var pbkdf2 = new Rfc2898DeriveBytes(password, user.Salt);
            //pbkdf2.IterationCount = 1000;
            //user.Password = pbkdf2.GetBytes(32);

            user.Salt = Guid.NewGuid();
            string soltedPassword = user.Password + user.Salt;
            var passwordBytes = Encoding.UTF8.GetBytes(soltedPassword);
            HashAlgorithm sha512 = SHA512.Create();
            user.PasswordBytes = sha512.ComputeHash(passwordBytes);

            //_users.Add(user);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            //var user = _context.Users.SingleOrDefault(u => u.UserName == request.UserName && u.Password == request.Password);
            var user = _context.Users.SingleOrDefault(u => u.UserName == request.UserName);
            if (user == null)
            {
                return null;
            }
            if(!user.IsAuthentic("", request.Password))
            {
                return null;
            }
            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public User GetById(int id) => _context.Users.FirstOrDefault(u => u.UserId == id);

        private string GenerateJwtToken(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_authSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.UserId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.UserName),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.WindowsAccountName, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Issuer = "BankApp.WebApi",
                Audience = "BankApp",
                Claims = new Dictionary<string, object>
                {
                    { "test", 42 }
                },
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
