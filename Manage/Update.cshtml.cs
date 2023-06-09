using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonayogDianaFinalExam.Manage
{
    public class Update : PageModel
    {
        private readonly ILogger<Update> _logger;
        private readonly ICarService _carService;
        [BindProperty]
        public ViewModel Data { get; set; }
        public Update(ILogger<Update> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;

            Data = Data ?? new ViewModel();
        }

        public IActionResult OnGet(Guid? id = null)
        {
            if (id == null)
            {
                return RedirectPermanent("~/manage/cars/create");
            }

            var carDto = _carService.GetById(id);

            if (carDto != null)
            {
                Data.Car = carDto;
            }
            else
            {
                return RedirectPermanent("~/manage/cars/create");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid != true)
                return Page();

            _carService.Update(Data.Car);

            return RedirectPermanent("~/manage/cars/index");
        }

        public class ViewModel
        {
            public CarDto? Car { get; set; }
        }
    }
}