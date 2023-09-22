using System.Text;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TodoAPI.Data.Entities;

namespace TodoAPI.Utils
{
    public class Helper
    {
        public static string CheckPassword(string passwd)
        {
            if (passwd.Length < 8 || passwd.Length > 14)
            {
                return "Min 8 char and max 14 char";
            }
            if (!passwd.Any(char.IsUpper))
            {
                return "One Upper Case";
            }
            if (!passwd.Any(char.IsLower))
            {
                return "Atleast one lower case";
            }
            if (passwd.Contains(" "))
            {
                return "No white space";
            }

            return string.Empty;
        }

        public static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }

        public static string CreateToken(byte[] secretKey, Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha512)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
