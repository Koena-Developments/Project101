using System.Security.Claims;
using FoodBev.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodBev.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var token = _authService.Authenticate(request.Email, request.Password);
        if (token == null)
            return Unauthorized(new { message = "Invalid credentials" });

        var user = _authService.GetUserById(Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? ""));
        return Ok(new { token, role = User.FindFirst(ClaimTypes.Role)?.Value });
    }


    [HttpPost("register")]

    public IActionResult Register([FromBody] RegisterRequest request)
    {
        
    }
}

public record LoginRequest(string Email, string Password);