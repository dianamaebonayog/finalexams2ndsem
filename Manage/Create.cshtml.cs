using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonayogDianaFinalExam.Manage.User; 
public class Create : PageModel
{
    private readonly ILogger<Create> _logger;
    private readonly IUserService _UserService;
    [BindProperty]
    public ViewModel Data { get; set; }
    public Create(ILogger<Create> logger, IUserService UserService)
    {
        _logger = logger;
        _UserService = UserService;

        Data = Data ?? new ViewModel();
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid != true)
            return Page();

        _UserService.Create(Data.User);

        return RedirectPermanent("~/manage/index");
    }

    public class ViewModel
    {
        public UserDto? User { get; set; }
    }
}

