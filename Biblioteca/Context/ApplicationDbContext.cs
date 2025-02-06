using Biblioteca.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace Biblioteca.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Marcos",
                    UserName = "MarcosHau",
                    Password = "marcoshau",
                    FkRol = 1
                });
            //Inserta tabla Rol
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {

                    PkRol = 1,
                    Nombre = "Admin"
                });
        }

        }
}
