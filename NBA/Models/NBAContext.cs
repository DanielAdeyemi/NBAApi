using Microsoft.EntityFrameworkCore;

namespace NBA.Models
{
  public class NBAContext : DbContext
  {
    public virtual DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }

    public NBAContext(DbContextOptions<NBAContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Team { AnimalId = 1, Name = "Matilda", Species = "Woolly Mammoth", Age = 7, Gender = "Female" },

        );
    }
  }
}