using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TasksTrackingApp.Domain.Abstractions;
using TasksTrackingApp.Domain.Enums;
using TasksTrackingApp.Infrastructure.Persistence;

namespace TasksTrackingApp.Services.AuthService
{
    public class AuthService(IConfiguration configuration, TasksDbContext tasksDbContext) : IAuthService
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly TasksDbContext _tasksDbContext = tasksDbContext;

        public string GenerateJwtToken(string email, string userName)
        {
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];
            var key = _configuration["JWT:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new("Email", email),
                new("UserName", userName),
                new("EmailIdentifier", email.Split("@").ToString()!),
                new("CurrentTime", DateTime.Now.ToString())
            };

            _ = Double.TryParse(_configuration["JWT:TokenExpirationTimeInHours"]!.ToString(), out double expirationTime);

            var token = new JwtSecurityToken(issuer,
                audience,
                claims,
                expires: DateTime.Now.AddHours(expirationTime),
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var secureRandomBytes = new byte[128];
            
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(secureRandomBytes);

            return Convert.ToBase64String(secureRandomBytes);
        }

        public string HashingPassword(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                //x2 pega a representação hexadecimal
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public bool CheckUniqueUserAndEmail(string email, string userName)
        {
            var users = _tasksDbContext.Users.ToList();

            var emailExists = users.Exists(x => x.Email == email);
            var userNameExists = users.Exists(x => x.Username == userName);

            if(emailExists || userNameExists) { return false; }

            return true;
        }
    }
}
