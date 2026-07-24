using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Question_04_ValidateJWTExpiry.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Question_04_ValidateJWTExpiry.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        if (model.Username == "admin" && model.Password == "admin123")
        {
            var token = GenerateJwtToken(model.Username);

            return Ok(new
            {
                Token = token
            });
        }

        return Unauthorized();
    }

    private string GenerateJwtToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtToken"));

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "MyAuthServer",
            audience: "MyApiUsers",
            claims: claims,

            // Change to 2 minutes to test expiry
            expires: DateTime.Now.AddMinutes(2),

            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}