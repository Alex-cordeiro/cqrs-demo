using System;
using CQRS.Demo.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRS.Demo.API.Data.Mappings;

public class MecanicoMap : IEntityTypeConfiguration<Mecanico>
{
    public void Configure(EntityTypeBuilder<Mecanico> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(150);
    }
}
