using AByteOf熊猫Apis.Data;
using AByteOf熊猫Apis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AByteOf熊猫Apis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UsuarioContext _context;

    public UsersController(UsuarioContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (await _context.Usuarios.AnyAsync(u => u.Correo == model.Email))
            return BadRequest("El correo ya está registrado");

        var usuario = new Usuarios
        {
            Nombre = model.Name,
            Correo = model.Email,
            Contrasena = model.Password // Almacenar en texto plano
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok("Usuario registrado exitosamente");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == model.Email);

        if (usuario == null || usuario.Contrasena != model.Password)
            return Unauthorized("Credenciales inválidas");

        return Ok("Inicio de sesión exitoso");
    }
}

public class RegisterModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}