using BloodDonation.Core.Services;
using System.Security.Cryptography;
using System.Text;

namespace BloodDonation.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        public AuthService() { }

        public string ComputeSha256Hash(string password)
        {
            // ComputeHash - retorna byte array  
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

            // Converte byte array para string   
            var builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2")); // x2 faz com que seja convertido em representação hexadecimal
            }

            return builder.ToString();
        }

        public string GenerateJwtToken(string email, string role)
        {
            throw new NotImplementedException();
        }
    }
}
