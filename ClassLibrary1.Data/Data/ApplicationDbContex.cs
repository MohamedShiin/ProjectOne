using ClassLibrary2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
                
namespace ClassLibrary1.Data
{ 
    public class ApplicationDbContex:IdentityDbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {
                
        } 
        public DbSet<category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; } 
        public DbSet<Product> products{ get; set; }
    }
}
