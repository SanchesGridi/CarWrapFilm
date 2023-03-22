using CarWrapFilm.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarWrapFilm.Pages;

public class IndexModel : PageModel
{
    private readonly List<FilmWrappingKit> _kits;
    private readonly List<FilmWrappingKit> _works;
    private readonly ILogger<IndexModel> _logger;

    public string Title => "Цены";
    public string Currency => "BYN";
    public List<FilmWrappingKit> Kits => _kits;
    public List<FilmWrappingKit> Works => _works;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _kits = GenerateKits();
        _works = GenerateWorks();
    }

    private static List<FilmWrappingKit> GenerateKits() =>
        new()
        {
            new("Минимум", 200, new[] { "Полоса на капот", "Полоса на крышу", "Фары" }),
            new("Базовый", 250, new[] { "Полоса на капот", "Передние стойки", "Полоса на крышу", "Фары" }),
            new("Стандарт", 650, new[] { "Капот полностью", "Передние крылья", "Передние стойки", "Полоса на крышу", "Фары" }),
            new("Максимум", 3000, new[] { "Оклейка всего авто", "Конечная стоимость рассчитывается индивидуально" })
        };

    private static List<FilmWrappingKit> GenerateWorks() =>
        new()
        {
            new("Полоса на капот", 100),
            new("Капот полностью", 280),
            new("Передние крылья", 230),
            new("Полоса на крышу", 60),
            new("Передние стойки", 70),
            new("Фары", 60)
        };
}
