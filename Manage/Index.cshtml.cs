using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BonayogDianaFinalExam.Manage
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IUserService _carService;
        [BindProperty]
        public ViewModel Data { get; set; }
        public Index(ILogger<Index> logger, IUserService UserService)
        {
            _logger = logger;
            _UserService = UserService;

            Data = Data ?? new ViewModel();
        }

        public void OnGet(int? pageIndex = 1, int? pageSize = 10, string? sortBy = "", SortOrder sortOrder = SortOrder.Ascending, string? keyword = "")
        {
            Data.User = _UserService.Search(pageIndex, pageSize, sortBy, sortOrder, keyword);
        }

        public class ViewModel
        {
            public Paged<UserDto>? User { get; set; }
        }
    }
}