using AByteOf熊猫Apis.Models;
using Microsoft.EntityFrameworkCore;

namespace AByteOf熊猫Apis.Data
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) { }
    }
}
