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
            //clave compuesta de CuponDetalle
            modelBuilder.Entity<CuponDetalle>()
                .HasKey(cd => new { cd.CuponId, cd.ArticuloId });

            modelBuilder.Entity<CuponClienteModel>()
                .HasKey(cc => new(cc.NroCupon, cc.Id_Usuario));

            modelBuilder.Entity<CuponHistorialModel>()
                .HasKey(ch => new { ch.Id, ch.UsuarioId});

            base.OnModelCreating(modelBuilder);
        }


    }
}
