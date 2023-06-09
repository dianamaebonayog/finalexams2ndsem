using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonayogDianaFinalExam.Manage
{
    public class Delete : PageModel
    {
        private readonly ILogger<Delete> _logger;
        private readonly ICarService _carService;
        [BindProperty]
        public ViewModel Data { get; set; }
        public Delete(ILogger<Delete> logger, ICarService carService)
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
            _carService.Delete(Data.Car!.Id);

            return RedirectPermanent("~/manage/cars/index");
        }

        public class ViewModel
        {
            public CarDto? Car { get; set; }
        }
    }
}