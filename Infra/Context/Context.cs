using Domain.Entity;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public class DBContext : DbContext
{
    public DbSet<Servico> Servico { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Agendamento> Agendamento { get; set; }

    public DBContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
    }
}