

using API.Entity;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    protected readonly IConfiguration _config;

    public DataContext(IConfiguration config)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("MachineDatabase");
    }

    public DbSet<Time> Times { get; set; }
    public DbSet<Machine> Machines { get; set; }
}