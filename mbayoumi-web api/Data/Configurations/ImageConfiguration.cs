using mbayoumi_web_api.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace mbayoumi_web_api.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.ImageBytes)
               .HasColumnType("varbinary(max)")
               .HasMaxLength(10)
               .IsRequired();

        }
    }
}
