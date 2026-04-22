using System;
using CQRS.Demo.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Demo.API.Data.Mappings;

public class OrdemServicoMap : IEntityTypeConfiguration<OrdemServico>
{
    public void Configure(EntityTypeBuilder<OrdemServico> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.HasOne(x => x.Orcamento)
            .WithOne(x => x.OrdemServico)
            .HasForeignKey<OrdemServico>(x => x.OrcamentoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Veiculo)
            .WithMany(x => x.OrdensServico)
            .HasForeignKey(x => x.VeiculoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Mecanico)
            .WithMany(x => x.OrdemServicos)
            .HasForeignKey(x => x.MecanicoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
