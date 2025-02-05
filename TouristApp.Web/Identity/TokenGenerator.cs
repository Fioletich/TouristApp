using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TouristApp.Domain.Models.User;

namespace TouristApp.Web.Identity;

public class TokenGenerator(IConfiguration configuration) {
    public string GenerateToken(User user) {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.Default.GetBytes(configuration["JwtSettings:Key"]!);
        var currentTime = DateTime.UtcNow;
        var expirationTime = currentTime.AddHours(1);

        var claims = new List<Claim>
        {
            new Claim("role", user.Role.Name),
            new Claim(JwtRegisteredClaimNames.Jti, currentTime.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Exp, expirationTime.ToString()),
            new Claim("password", user.Password),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = configuration["JwtSettings:Issuer"],
            Audience = configuration["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}