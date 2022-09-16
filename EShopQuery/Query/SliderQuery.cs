using EShopQuery.Contracts.Slider;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Infrastructure.EFCore;

namespace EShopQuery.Query;

public class SliderQuery : ISliderQuery
{
    private readonly ShopManagerEFCoreDbContext Context;

    public SliderQuery(ShopManagerEFCoreDbContext context)
    {
        Context = context;
    }

    public List<SliderQueryModel> GetViewModels()
    {
        return Context.Sliders.AsNoTracking().Where(q => q.IsRemoved == false)
            .Select(x => new SliderQueryModel()
            {
                BodyText = x.BodyText,
                ButtonText = x.ButtonText,
                Heading = x.Heading,
                RedirectUrl = x.RedirectUrl,
                PicturePath = x.PicturePath,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title

            }).ToList();
    }
}
