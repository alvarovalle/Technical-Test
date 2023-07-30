namespace Backend.State;
using Microsoft.EntityFrameworkCore;    
public class Context : DbContext, IDisposable
{
    public DbSet<Listing> Listing { get; set; }
    public Context(DbContextOptions<Context> options)
    : base(options)
{ }
}