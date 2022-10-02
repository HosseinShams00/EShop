using EShopQuery.Contracts.Admin.Slider;
using BaseFramework.Application.Exceptions;
using SecondaryDB.Infrastructure.EFCore;
using ShopManagement.Application.Contract.SliderAgg.Command;

namespace EShopQuery.Query.Admin.Slider;

public class AdminSliderQuery : IAdminSliderQuery
{
    private readonly SecondaryDBEfCoreContext _context;

    public AdminSliderQuery(SecondaryDBEfCoreContext context)
    {
        _context = context;
    }

    public EditSlider GetDetail(long id)
    {
        var command = _context.SliderQueries
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

    public List<SliderQueryModel> GetViewModelsWith(bool isRemoved)
    {
        return _context.SliderQueries
            .Where(q => q.IsRemoved == isRemoved)
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
