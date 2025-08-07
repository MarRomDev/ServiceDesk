using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain.Tickets;

namespace ServiceDesk.Persistence.DbContext;

public class ServiceDeskDbContext(DbContextOptions<ServiceDeskDbContext> options)
    : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceDeskDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}