using ShopManagement.Application.Contract.SliderAgg.Command;

namespace ShopManagement.Application.Contract.SliderAgg;

public interface ISliderApplication
{
    void Create(CreateSlider createSlider);
    void Update(EditSlider editSlider);
    void Delete(long id);
    void Restore(long id);
}
