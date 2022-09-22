using EShopQuery.Contracts.Admin.Slider;
using ShopManagement.Application.Constracts.SliderAgg.Command;
using ShopManagement.Infrastructure.EFCore;
using BaseFramwork.Application.Exceptions;

namespace EShopQuery.Query.Admin.Slider;

public class AdminSliderQuery : IAdminSliderQuery
{
    private readonly ShopManagerEFCoreDbContext Context;

    public AdminSliderQuery(ShopManagerEFCoreDbContext context)
    {
        Context = context;
    }

    public EditSlider GetDetail(long id)
    {
        var command = Context.Sliders
            .Select(x => new EditSlider()
            {
                Id = x.Id,
                BodyText = x.BodyText,
                ButtonText = x.ButtonText,
                Heading = x.Heading,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PicturePath = x.PicturePath,
                RedirectUrl = x.RedirectUrl,
                Title = x.Title
            })
            .FirstOrDefault(q => q.Id == id);

        if (command == null)
            throw new EntityNotFoundException();

        return command;

    }

    public List<SliderQueryModel> GetViewModelsWith(bool IsRemoved)
    {
        return Context.Sliders
            .Where(q => q.IsRemoved == IsRemoved)
            .Select(x => new SliderQueryModel()
            {
                Id = x.Id,
                Heading = x.Heading,
                RedirectUrl = x.RedirectUrl,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,
                PicturePath = x.PicturePath
            })
            .ToList();
    }
}
