using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace ShopManagement.Application.Constracts.SliderAgg;

public interface ISliderApplication
{
    void Create(CreateSlider createSlider);
    void Update(EditSlider editSlider);
    void Delete(long id);
    void Restore(long id);
}
