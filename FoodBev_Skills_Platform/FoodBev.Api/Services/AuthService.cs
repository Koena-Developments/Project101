using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FoodBev.Api.Services;
// 
public class AuthService
{
    private readonly List<User> _users = new()
    {
        new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Email = "student@example.com", PasswordHash = "pass", Role = "Student" },
        new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Email = "company@nestle.com", PasswordHash = "pass", Role = "Company" },
        new() { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Email = "admin@foodbev.co.za", PasswordHash = "pass", Role = "Admin" }
    };

    private readonly JwtSettings _jwtSettings;

    public AuthService(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string? Authenticate(string email, string password)
    {
        var user = _users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        if (user == null) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public User? GetUserById(Guid id) => _users.FirstOrDefault(u => u.Id == id);
}

public class JwtSettings
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpiryMinutes { get; set; }
}