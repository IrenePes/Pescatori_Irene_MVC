using EsercitazioneFinale.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EsercitazioneFinale.RepositoryEF
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.MenuID);
            builder.Property(m => m.Nome).IsRequired();

            builder.HasMany(m => m.Piatti).WithOne(p => p.Menu).HasForeignKey(m => m.MenuID);
        }
    }
}