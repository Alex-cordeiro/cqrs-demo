using System;
using CQRS.Demo.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Demo.API.Data.Mappings;

public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Placa)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasOne(x => x.Modelo)
            .WithMany(x => x.Veiculos)
            .HasForeignKey(x => x.ModeloId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Ano)
            .IsRequired().HasMaxLength(4);
    }
}
