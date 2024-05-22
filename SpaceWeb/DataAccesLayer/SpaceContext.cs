using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpaceWeb.Models;

namespace SpaceWeb.DataAccesLayer
{
    public class SpaceContext : IdentityDbContext<User>
    {
        public SpaceContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Offers> Offers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=LAPTOP-ACG39MDK\\SQLEXPRESS;Database=Space;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(options);
        }
    }
}
