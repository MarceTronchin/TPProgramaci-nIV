using Microsoft.EntityFrameworkCore;
using trabajoPracticoProgramacio4.Models;
using trabajoPracticoProgramacion4.Models;

namespace trabajoPracticoProgramacion4.Context
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Usuarios { get; set; }
        public DbSet<RolModel> Roles { get; set; }
        public DbSet<CuponModel> Cupones { get; set; }
        public DbSet<CuponClienteModel> CuponesClientes { get; set; }
        public DbSet<CuponHistorialModel> CuponesHistorial{ get; set; }
        public DbSet<ArticuloModel> Articulos { get; set; }
        public DbSet<TipoCuponModel> TiposCupones { get; set; }
        public DbSet<CuponDetalle> CuponesDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- Configuración para CuponModel (PK) ---
            // Entity Framework automáticamente detecta Id_Cupon como PK si sigues la convención.
            // Pero como antes era NroCupon, es bueno confirmarlo explícitamente si hay dudas,
            // aunque con los atributos ya debería ser suficiente.


            // --- Clave compuesta para CuponDetalle ---
            // Aquí se especifica que la clave primaria de Cupones_Detalle está compuesta por Id_Cupon y IdArticulo.
            modelBuilder.Entity<CuponDetalle>()
                .HasKey(cd => new { cd.Id_Cupon, cd.IdArticulo }); // Usar Id_Cupon y IdArticulo

            // Configurar la relación entre CuponDetalle y CuponModel
            modelBuilder.Entity<CuponDetalle>()
                .HasOne(cd => cd.Cupon) // CuponDetalle tiene un Cupon
                .WithMany(c => c.CuponesDetalles) // Un Cupon tiene muchos CuponesDetalles
                .HasForeignKey(cd => cd.Id_Cupon); // La FK en CuponDetalle es Id_Cupon

            // Configurar la relación entre CuponDetalle y ArticuloModel
            modelBuilder.Entity<CuponDetalle>()
                .HasOne(cd => cd.Articulo) // CuponDetalle tiene un Articulo
                .WithMany() // Un Articulo puede tener muchos CuponesDetalles, pero no necesitamos una propiedad de navegación de regreso en ArticuloModel por ahora.
                            // Si en ArticuloModel agregas: public ICollection<CuponDetalle> CuponesDetalles { get; set; }
                            // entonces WithMany() cambia a WithMany(a => a.CuponesDetalles)
                .HasForeignKey(cd => cd.IdArticulo); // La FK en CuponDetalle es IdArticulo


            // --- Clave compuesta para CuponClienteModel ---
            // Aquí se especifica que la clave primaria de Cupones_Clientes está compuesta por Id_Cupon y Id_Usuario.
            modelBuilder.Entity<CuponClienteModel>()
                .HasKey(cc => new { cc.Id_Cupon, cc.Id_Usuario }); // Usar Id_Cupon y Id_Usuario

            // Configurar la relación entre CuponClienteModel y CuponModel
            modelBuilder.Entity<CuponClienteModel>()
                .HasOne(cc => cc.Cupon) // CuponClienteModel tiene un Cupon
                .WithMany(c => c.CuponesClientes) // Un Cupon tiene muchos CuponesClientes
                .HasForeignKey(cc => cc.Id_Cupon); // La FK en CuponClienteModel es Id_Cupon

            // Configurar la relación entre CuponClienteModel y UserModel
            modelBuilder.Entity<CuponClienteModel>()
                .HasOne(cc => cc.Usuario) // CuponClienteModel tiene un Usuario
                .WithMany() // Un Usuario puede tener muchos Cupones_Clientes, pero no necesitamos una propiedad de navegación de regreso en UserModel por ahora.
                .HasForeignKey(cc => cc.Id_Usuario); // La FK en CuponClienteModel es Id_Usuario


            // --- Clave primaria para CuponHistorialModel ---
            // Aquí estamos asumiendo que agregaste IdHistorial como PK autoincremental en el modelo.
            // Si elegiste una clave compuesta, la configuración aquí sería similar a CuponDetalle.
            modelBuilder.Entity<CuponHistorialModel>()
                .HasKey(ch => ch.IdHistorial); // Usar la nueva propiedad IdHistorial como PK

            // Configurar la relación entre CuponHistorialModel y UserModel
            modelBuilder.Entity<CuponHistorialModel>()
                .HasOne(ch => ch.Usuario) // CuponHistorialModel tiene un Usuario
                .WithMany() // Un Usuario puede tener muchos Cupones_Historial
                .HasForeignKey(ch => ch.Id_Usuario); // La FK en CuponHistorialModel es Id_Usuario

            // Configurar la relación entre CuponHistorialModel y CuponModel
            modelBuilder.Entity<CuponHistorialModel>()
                .HasOne(ch => ch.Cupon) // CuponHistorialModel tiene un Cupon
                .WithMany() // Un Cupon puede tener muchos Cupones_Historial
                .HasForeignKey(ch => ch.Id_Cupon); // La FK en CuponHistorialModel es Id_Cupon


            // --- Configuración adicional para UserModel (corregir Dni) ---
            // Si la propiedad en UserModel es 'dni' (minúscula) y en RegistroUsuarioDTO es 'Dni' (mayúscula),
            // y quieres que en la DB se llame 'dni', la Fluent API puede asegurar eso:
            modelBuilder.Entity<UserModel>()
                .Property(u => u.dni)
                .HasColumnName("dni"); // Esto asegura que la columna en la DB se llame 'dni'


            base.OnModelCreating(modelBuilder);
        } 


    }
}
