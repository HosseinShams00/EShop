using EShopQuery.Contracts.User.Slider;
using SecondaryDB.Infrastructure.EFCore;

namespace EShopQuery.Query.User;

public class UserSliderQuery : IUserSliderQuery
{
    private readonly SecondaryDBEfCoreContext _context;

    public UserSliderQuery(SecondaryDBEfCoreContext context)
    {
        _context = context;
    }

    public List<SliderQueryModel> GetViewModels()
    {
        return _context.SliderQueries
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
