using BaseFramwork.Repository;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Application.Constracts.SliderAgg.Command;
using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository;

public class SliderRepository : BaseRepository<long, Slider>, ISliderRepository
{
    private readonly EFCoreDbContext Context;

    public SliderRepository(EFCoreDbContext context) : base(context)
    {
        Context = context;
    }

    public EditSlider? GetDetails(long id)
    {
        return Context.Sliders.Select(x => new EditSlider()
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
        }).FirstOrDefault(q => q.Id == id);
    }

    public List<SliderViewModel> GetViewModelsWith(bool IsRemoved)
    {
        return Context.Sliders.Where(q => q.IsRemoved != IsRemoved)
            .Select(x => new SliderViewModel()
            {
                Id = x.Id,
                Heading = x.Heading,
                RedirectUrl = x.RedirectUrl,
                CreationTime = x.CreationTime.ToString(),
                IsRemoved = x.IsRemoved,
                PicturePath = x.PicturePath
            }).ToList();
    }
}
