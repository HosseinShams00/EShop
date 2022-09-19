using EShopQuery.Contracts.Admin.Slider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Sliders
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditSlider _Command { get; set; }
        private readonly ISliderApplication _Application;
        private readonly IAdminSliderQuery _AdminSliderQuery;


        public EditModel(ISliderApplication sliderApplication, IAdminSliderQuery adminSliderQuery)
        {
            _Application = sliderApplication;
            _AdminSliderQuery = adminSliderQuery;
        }

        public void OnGet(long id)
        {
            _Command = _AdminSliderQuery.GetDetail(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
                return Page();

            _Application.Update(_Command);
            return RedirectToPage("./index");
        }
    }
}
