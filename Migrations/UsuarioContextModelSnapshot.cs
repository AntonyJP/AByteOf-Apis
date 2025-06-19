using AByteOf熊猫Apis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AByteOf熊猫Apis.Migrations
{
    [DbContext(typeof(UsuarioContext))]
    partial class UsuarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiUsuariosTest.Models.Usuarios", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Contrasena")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Correo")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Nombre")
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnType("nvarchar(75)");

                b.HasKey("Id");

                b.ToTable("Usuarios");
            });
#pragma warning restore 612, 618
        }
    }
}