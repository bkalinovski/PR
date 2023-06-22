using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PR.Domain.Shared;
using PR.Domain.Tara;

namespace PR.Persistance.Configurations;

internal class TaraConfiguration : IEntityTypeConfiguration<Tara>
{
    public void Configure(EntityTypeBuilder<Tara> builder)
    {
        builder.ToTable("Tara")
            .HasKey(t => t.CodTara);
        
        builder.Property(t => t.CodTara)
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Denumire)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Continent)
            .HasColumnType("nvarchar(30)")
            .HasMaxLength(30)
            .HasConversion(continent => continent.ToString(), s => (Continent)Enum.Parse(typeof(Continent), s))
            .IsRequired();

        builder.HasMany(t => t.Orase)
            .WithOne(t => t.Tara)
            .HasPrincipalKey(t => t.CodTara)
            .HasForeignKey(t => t.CodTara)
            .IsRequired();
    }
}