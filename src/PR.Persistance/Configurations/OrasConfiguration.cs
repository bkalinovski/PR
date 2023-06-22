using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PR.Domain.Oras;

namespace PR.Persistance.Configurations;

internal class OrasConfiguration : IEntityTypeConfiguration<Oras>
{
    public void Configure(EntityTypeBuilder<Oras> builder)
    {
        builder.ToTable("Oras")
            .HasKey(t => t.CodOras);
        
        builder.Property(t => t.CodOras)
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Denumire)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.NumarLocuitori)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(t => t.Tara)
            .WithMany(t => t.Orase)
            .HasPrincipalKey(t => t.CodTara)
            .HasForeignKey(t => t.CodTara)
            .IsRequired();
    }
}