using BaseFramework.Application;
using BaseFramework.Application.Exceptions;
using SecondaryDB.Domain.SliderQueryAgg;
using ShopManagement.Application.Contract.SliderAgg;
using ShopManagement.Application.Contract.SliderAgg.Command;
using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.Application.SliderAgg;

public class SliderApplication : ISliderApplication
{
    private readonly ISliderRepository _sliderRepository;
    private readonly ISliderQueryRepository _sliderQueryRepository;

    public SliderApplication(ISliderRepository sliderRepository, ISliderQueryRepository sliderQueryRepository)
    {
        _sliderRepository = sliderRepository;
        _sliderQueryRepository = sliderQueryRepository;
    }
    public void Create(CreateSlider createSlider)
    {
        var entity = new Slider(createSlider.PicturePath, createSlider.PictureAlt,
            createSlider.PictureTitle, createSlider.Heading,
            createSlider.Title, createSlider.BodyText,
            createSlider.ButtonText, createSlider.RedirectUrl);

        _sliderRepository.Create(entity);

        var sliderQuery = Convertor.Convert<SliderQuery>(entity);
        _sliderQueryRepository.Create(sliderQuery);

    }

    public void Delete(long id)
    {
        var entity = _sliderRepository.GetBy(id);
        if (entity == null)
            throw new EntityNotFoundException();

        entity.DeActive();
        _sliderRepository.UpdateEntity(entity);

        var sliderQuery = _sliderQueryRepository.Get(x => x.Id == entity.Id);
        sliderQuery.IsRemoved = entity.IsRemoved;
        _sliderQueryRepository.UpdateEntity(sliderQuery);
    }

    public void Restore(long id)
    {
        var entity = _sliderRepository.GetBy(id);
        if (entity == null)
            throw new EntityNotFoundException();

        entity.Active();
        _sliderRepository.UpdateEntity(entity);

        var sliderQuery = _sliderQueryRepository.Get(x => x.Id == entity.Id);
        sliderQuery.IsRemoved = entity.IsRemoved;
        _sliderQueryRepository.UpdateEntity(sliderQuery);
    }

    public void Update(EditSlider editSlider)
    {

        var entity = _sliderRepository.GetBy(editSlider.Id);
        if (entity == null)
            throw new EntityNotFoundException();

        entity.Edit(editSlider.PicturePath, editSlider.PictureAlt,
            editSlider.PictureTitle, editSlider.Heading,
            editSlider.Title, editSlider.BodyText,
            editSlider.ButtonText, editSlider.RedirectUrl);

        _sliderRepository.UpdateEntity(entity);

        var sliderQuery = _sliderQueryRepository.Get(x => x.Id == entity.Id);
        Convertor.Copy(entity, sliderQuery);
        _sliderQueryRepository.UpdateEntity(sliderQuery);
    }
}
