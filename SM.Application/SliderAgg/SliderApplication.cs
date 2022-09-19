using BaseFramwork.Application.Exceptions;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Application.Constracts.SliderAgg.Command;
using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.Application.SliderAgg;

public class SliderApplication : ISliderApplication
{
    private readonly ISliderRepository SliderRepository;

    public SliderApplication(ISliderRepository sliderRepository)
    {
        SliderRepository = sliderRepository;
    }
    public void Create(CreateSlider createSlider)
    {
        var slider = new Slider(createSlider.PicturePath, createSlider.PictureAlt,
            createSlider.PictureTitle, createSlider.Heading,
            createSlider.Title, createSlider.BodyText,
            createSlider.ButtonText, createSlider.RedirectUrl);

        SliderRepository.Create(slider);
    }

    public void Delete(long id)
    {
        var slider = SliderRepository.GetBy(id);
        if (slider == null)
            throw new EntityNotFoundException();

        slider.DeActive();
        SliderRepository.UpdateEntity(slider);
    }

    public void Restore(long id)
    {
        var slider = SliderRepository.GetBy(id);
        if (slider == null)
            throw new EntityNotFoundException();

        slider.Active();
        SliderRepository.UpdateEntity(slider);
    }

    public void Update(EditSlider editSlider)
    {

        var slider = SliderRepository.GetBy(editSlider.Id);
        if (slider == null)
            throw new EntityNotFoundException();

        slider.Edit(editSlider.PicturePath, editSlider.PictureAlt,
            editSlider.PictureTitle, editSlider.Heading,
            editSlider.Title, editSlider.BodyText,
            editSlider.ButtonText, editSlider.RedirectUrl);

        SliderRepository.UpdateEntity(slider);
    }
}
