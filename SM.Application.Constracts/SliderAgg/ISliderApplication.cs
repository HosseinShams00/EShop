using ShopManagement.Application.Constracts.ProductPictureAgg.Command;
using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace ShopManagement.Application.Constracts.SliderAgg;

public interface ISliderApplication
{
    void Create(CreateSlider createSlider);
    void Update(EditSlider editSlider);
    EditSlider GetDetail(long id);
    void Delete(long id);
    void Restore(long id);
    List<SliderViewModel> GetViewModels(long id);
}
