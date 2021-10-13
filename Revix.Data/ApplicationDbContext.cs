using Microsoft.EntityFrameworkCore;
using Revix.Models;

namespace Revix.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CryptoListing> CryptoListings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}