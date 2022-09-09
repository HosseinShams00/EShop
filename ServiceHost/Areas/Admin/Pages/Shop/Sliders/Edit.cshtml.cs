using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constracts.SliderAgg;
using ShopManagement.Application.Constracts.SliderAgg.Command;

namespace ServiceHost.Areas.Admin.Pages.Shop.Sliders
{
    public class EditModel : PageModel
    {
        [BindProperty] public EditSlider editSlider { get; set; }
        private readonly ISliderApplication SliderApplication;

        public EditModel(ISliderApplication sliderApplication)
        {
            this.SliderApplication = sliderApplication;
        }

        public void OnGet(long id)
        {
            editSlider = SliderApplication.GetDetail(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
                return Page();

            SliderApplication.Update(editSlider);
            return RedirectToPage("./index");
        }
    }
}
