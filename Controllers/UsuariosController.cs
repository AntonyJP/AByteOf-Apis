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
        if (await _context.Usuarios.AnyAsync(u => u.Correo == model.Correo))
            return BadRequest("El correo ya está registrado");

        var usuario = new Usuarios
        {
            Nombre = model.Nombre,
            Correo = model.Correo,
            Contrasena = model.Contrasena // Almacenar en texto plano
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok("Usuario registrado exitosamente");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == model.Correo);

        if (usuario == null || usuario.Contrasena != model.Contrasena)
            return Unauthorized("Credenciales inválidas");

        return Ok(new { message = "Inicio de sesión exitoso", idUsuario = usuario.Id     });
    }
}

public class RegisterModel
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Contrasena { get; set; }
}

public class LoginModel
{
    public string Correo { get; set; }
    public string Contrasena { get; set; }
}