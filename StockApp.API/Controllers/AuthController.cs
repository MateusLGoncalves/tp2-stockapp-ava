using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("/api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    // POST /api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login()
    {
        // Criação de claims simuladas
        var claims = new List<Claim>
        {
            new Claim("Permission", "CanManageProducts"),
            new Claim(ClaimTypes.Name, "TestUser")
        };

        var identity = new ClaimsIdentity(claims, "CookieAuth");
        var principal = new ClaimsPrincipal(identity);

        // Salvar usuário no contexto HTTP
        await HttpContext.SignInAsync("CookieAuth", principal);

        return Ok(new { message = "Login realizado com sucesso!" });
    }

    // GET /api/auth/check-access
    [Authorize(Policy = "CanManageProducts")]
    [HttpGet("check-access")]
    public IActionResult CheckAccess()
    {
        return Ok(new { message = "Você tem permissão para acessar este recurso!" });
    }
}