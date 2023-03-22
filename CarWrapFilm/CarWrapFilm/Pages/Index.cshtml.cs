using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarWrapFilm.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string Title => "Цены";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
}
