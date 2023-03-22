using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarWrapFilm.Pages;

public class ServicesModel : PageModel
{
    private readonly ILogger<ServicesModel> _logger;

    public string Title => "Услуги";
    public string[] Brands { get; } = new[] { "Suntek", "Sunmax", "Solarnex Quantum", "Llumar", "G-suit", "Hogomaku" };
    public string TopBrand => Brands[0];

    public ServicesModel(ILogger<ServicesModel> logger)
    {
        _logger = logger;
    }
}
