using L.M.S.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace L.M.S.Application.Persistence.Sql;

public class LMSSqlContext : DbContext
{
    public LMSSqlContext(DbContextOptions<LMSSqlContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
           .HasMany(b => b.Categories)
           .WithMany(c => c.Books);
    }
}