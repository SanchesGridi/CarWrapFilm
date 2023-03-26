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

    public void OnGet()
    {

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
            new(1, "Минимум", 290, new[] { "Полоса на капот", "Полоса на крышу", "Фары" }),
            new(2, "Базовый", 375, new[] { "Полоса на капот", "Передние стойки", "Полоса на крышу", "Фары" }),
            new(3, "Стандарт", 875, new[] { "Капот полностью", "Передние крылья", "Передние стойки (лобового стекла)", "Полоса на крышу", "Фары" }),
            new(4, "Максимум", 3000, new[] { "Оклейка всего авто", "Конечная стоимость рассчитывается индивидуально" })
        };

    private static List<FilmWrappingKit> GenerateWorks()
    {
        var works = new List<FilmWrappingKit>()
        {
            new(0, "Багажник, зона погрузки", 50),
            new(0, "Глянцевые стойки дверей", 55),
            new(0, "Двери", 685),
            new(0, "Задняя часть арок", 85),
            new(0, "Зеркала", 85),
            new(0, "Зоны под ручками дверей, 4 штуки (маникюр)", 55),
            new(0, "Канты дверей, 4 штуки", 30),
            new(0, "Капот полностью", 360),
            new(0, "Низы дверей (20см)", 175),
            new(0, "Пароги, внутреняя часть, 4 штуки", 50),
            new(0, "Передние крылья", 260),
            new(0, "Передние стойки (лобового стекла)", 85),
            new(0, "Передний бампер", 400),
            new(0, "Передняя часть крыльев", 90),
            new(0, "Полоса на капот", 120),
            new(0, "Полоса на крышу", 85),
            new(0, "Фары", 85)
        }.OrderBy(x => x.Name).ToList();
        var startId = 5u;
        works.ForEach(x => x.Id = startId++);
        return works;
    }
      
}
