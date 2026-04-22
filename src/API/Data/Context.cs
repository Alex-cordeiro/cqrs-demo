using System;
using CQRS.Demo.API.Data.Mappings;
using CQRS.Demo.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Demo.API.Data;

public class Context : DbContext
{

    public Context(DbContextOptions options) : base(options)
    {
    }

    protected Context()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        new MarcaMap().Configure(modelBuilder.Entity<Marca>());
        new ModeloMap().Configure(modelBuilder.Entity<Modelo>());
        new VeiculoMap().Configure(modelBuilder.Entity<Veiculo>());
        new MecanicoMap().Configure(modelBuilder.Entity<Mecanico>());
        new OrcamentoMap().Configure(modelBuilder.Entity<Orcamento>());
        new OrcamentoItemMap().Configure(modelBuilder.Entity<OrcamentoItem>());
        new OrdemServicoMap().Configure(modelBuilder.Entity<OrdemServico>());

       base.OnModelCreating(modelBuilder);
    }
}
