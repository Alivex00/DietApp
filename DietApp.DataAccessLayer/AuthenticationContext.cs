using DietApp.DataAccessLayer.Interfaces;
using DietApp.DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DietApp.DataAccessLayer
{
    public class AuthenticationContext : IdentityDbContext, IDbContext
    {
        public AuthenticationContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
