using Microsoft.EntityFrameworkCore;
using DatabaseProvider.Entities;
using Microsoft.Extensions.Configuration;
namespace DatabaseProvider;

internal class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasMany(c => c.AuthorizedClerks);
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Partners);
        modelBuilder.Entity<Company>()
            .HasMany(c => c.Representatives);
        modelBuilder.Entity<Company>()
            .HasMany(c => c.AccountNumbers);

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Company> Companies { get; set; }
}
