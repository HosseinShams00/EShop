using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecondaryDB.Domain.SliderQueryAgg;

namespace SecondaryDB.Infrastructure.EFCore.Mapping;

public class SliderQueryMapping : IEntityTypeConfiguration<SliderQuery>
{
    public void Configure(EntityTypeBuilder<SliderQuery> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
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