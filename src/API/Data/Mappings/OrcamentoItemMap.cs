using System;
using CQRS.Demo.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Demo.API.Data.Mappings;

public class OrcamentoItemMap : IEntityTypeConfiguration<OrcamentoItem>
{
    public void Configure(EntityTypeBuilder<OrcamentoItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Valor)
             .IsRequired()
             .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Orcamento)
            .WithMany(x => x.Itens)
            .HasForeignKey(x => x.OrcamentoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
