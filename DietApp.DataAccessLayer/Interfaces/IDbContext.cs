using DietApp.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietApp.DataAccessLayer.Interfaces
{
    public interface IDbContext
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
