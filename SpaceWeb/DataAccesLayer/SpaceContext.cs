using Microsoft.EntityFrameworkCore;
using SpaceWeb.Models;

namespace SpaceWeb.DataAccesLayer
{
    public class SpaceContext : DbContext
    {
        public SpaceContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Offers> Offers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=CA-R214-PC05\\SQLEXPRESS;Database=Space;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(options);
        }
    }
}
