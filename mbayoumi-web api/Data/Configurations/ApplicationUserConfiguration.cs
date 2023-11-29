using mbayoumi_web_api.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace mbayoumi_web_api.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FirstName)
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .IsRequired();

            builder.Property(x => x.LastName)
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .IsRequired();

        }
    }
}
