using System.Security.Cryptography;
using System.Text;

namespace BankApp.Core.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public byte[] PasswordBytes { get; set; }
        public Guid Salt { get; set; }
        public string? Role { get; set; }

        public bool IsAuthentic(string username, string password)
        {
            //byte[] storedPassword = this.PasswordBytes;
            //byte[] storedSalt = this.Salt;

            //var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt);
            //pbkdf2.IterationCount = 1000;
            //byte[] computedPassword = pbkdf2.GetBytes(32);

            string soltedPassword = password + this.Salt;
            var passwordBytes = Encoding.UTF8.GetBytes(soltedPassword);
            HashAlgorithm sha512 = SHA512.Create();
            var computedPassword = sha512.ComputeHash(passwordBytes);

            return this.PasswordBytes.SequenceEqual(computedPassword);
        }
    }
}
