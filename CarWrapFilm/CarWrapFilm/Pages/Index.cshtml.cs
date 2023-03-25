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

    public async Task OnPostAsync(int serviceId, string user, string service, string question)
    {
        try
        {
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static List<FilmWrappingKit> GenerateKits() =>
        new()
        {
            new(1, "Минимум", 200, new[] { "Полоса на капот", "Полоса на крышу", "Фары" }),
            new(2, "Базовый", 250, new[] { "Полоса на капот", "Передние стойки", "Полоса на крышу", "Фары" }),
            new(3, "Стандарт", 650, new[] { "Капот полностью", "Передние крылья", "Передние стойки", "Полоса на крышу", "Фары" }),
            new(4, "Максимум", 3000, new[] { "Оклейка всего авто", "Конечная стоимость рассчитывается индивидуально" })
        };

    private static List<FilmWrappingKit> GenerateWorks() =>
        new()
        {
            new(5, "Полоса на капот", 100),
            new(6, "Капот полностью", 280),
            new(7, "Передние крылья", 230),
            new(8, "Полоса на крышу", 60),
            new(9, "Передние стойки", 70),
            new(10, "Фары", 60)
        };
}
