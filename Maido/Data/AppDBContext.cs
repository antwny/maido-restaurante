using Maido.Models;
using Microsoft.EntityFrameworkCore;

namespace Maido.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        public DbSet<Maido.Models.Usuario> Usuarios { get; set; }
        public DbSet<Maido.Models.Mesa> Mesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maido.Models.Usuario>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id).ValueGeneratedOnAdd();
                tb.Property(col => col.Contrasena).IsRequired().HasMaxLength(100);
                tb.Property(col => col.Rol).IsRequired().HasMaxLength(50);
                tb.Property(col => col.Nombre).IsRequired().HasMaxLength(100);
                tb.Property(col => col.NombreUsuario).IsRequired().HasMaxLength(50);
                tb.Property(col => col.Activo).IsRequired();
                tb.Property(col => col.FechaCreacion).IsRequired();
            });

            modelBuilder.Entity<Maido.Models.Mesa>(tb =>
            {
                tb.HasKey(col => col.Id);
                tb.Property(col => col.Id).ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre).IsRequired().HasMaxLength(100);
                tb.Property(col => col.Estado).IsRequired().HasMaxLength(50);
                tb.Property(col => col.Activa).IsRequired();
            });

            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Mesa>().ToTable("Mesas");
        }
    }
}
