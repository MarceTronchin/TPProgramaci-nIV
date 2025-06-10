using Microsoft.EntityFrameworkCore;
using trabajoPracticoProgramacio4.Models;

namespace trabajoPracticoProgramacion4.Context
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }




    }
}
