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

        public EditModel(ISliderApplication sliderApplication)
        {
            _Application = sliderApplication;
        }

        public void OnGet(long id)
        {
            _Command = _Application.GetDetail(id);
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
