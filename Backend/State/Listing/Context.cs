namespace Backend.State.Listing;
using Microsoft.EntityFrameworkCore;    
public class Context : DbContext, IDisposable
{
    public DbSet<Listing> Listing { get; set; }
    public DbSet<PostalAddress> PostalAddress { get; set; }
    public Context(DbContextOptions<Context> options)
    : base(options)
{ }
}