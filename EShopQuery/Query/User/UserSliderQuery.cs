using EShopQuery.Contracts.Slider;
using ShopManagement.Infrastructure.EFCore;

namespace EShopQuery.Query.User;

public class UserSliderQuery : IUserSliderQuery
{
    private readonly ShopManagerEFCoreDbContext Context;

    public UserSliderQuery(ShopManagerEFCoreDbContext context)
    {
        Context = context;
    }

    public List<SliderQueryModel> GetViewModels()
    {
        return Context.Sliders
            .Where(q => q.IsRemoved == false)
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
