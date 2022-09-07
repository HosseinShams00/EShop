using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping;

public class SliderMapping : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(x => x.BodyText).HasMaxLength(100);
        builder.Property(x => x.ButtonText).HasMaxLength(20).IsRequired();
        builder.Property(x => x.CreationTime);
        builder.Property(x => x.Heading).HasMaxLength(150);
        builder.Property(x => x.IsRemoved);
        builder.Property(x => x.PictureAlt).HasMaxLength(100);
        builder.Property(x => x.PicturePath).HasMaxLength(200).IsRequired();
        builder.Property(x => x.PictureTitle).HasMaxLength(100);
        builder.Property(x => x.RedirectUrl).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(100);
    }
}