using EsercitazioneFinale.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercitazioneFinale.RepositoryEF
{
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatti");
            builder.HasKey(p => p.PiattoID);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Descrizione).IsRequired();
            builder.Property(p => p.Prezzo).IsRequired();
            builder.Property(p => p.Prezzo).HasPrecision(5,2);
            builder.Property(p => p.Tipologia).IsRequired();

            builder.HasOne(p => p.Menu).WithMany(m => m.Piatti).HasForeignKey(p => p.MenuID);
        }
    }
}