namespace Backend.State.Listing;
using Microsoft.EntityFrameworkCore;    
public class Context : DbContext, IDisposable
{
    public DbSet<Listing> Listing { get; set; }
    public DbSet<PostalAddress> PostalAddress { get; set; }

    public Context(DbContextOptions<Context> options)
    : base(options)
    {

    }
/*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Host=localhost;Port=5432;Pooling=true;Database=Backend;User Id=postgres;Password=LltF8Nx*yo;";
        optionsBuilder.UseNpgsql(connectionString);
    }
*/
}