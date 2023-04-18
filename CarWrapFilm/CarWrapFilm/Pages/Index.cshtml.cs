using CarWrapFilm.Models;
using CarWrapFilm.Services;
using CarWrapFilm.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace CarWrapFilm.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMessageSender _messageSender;

    private readonly List<FilmWrappingKit> _kits;
    private readonly List<FilmWrappingKit> _works;

    public int NotExistingId => -1;
    public string Title => "Цены";
    public string Currency => "BYN";
    public List<FilmWrappingKit> Kits => _kits;
    public List<FilmWrappingKit> Works => _works;

    public string OrderInformation { get; set; } = string.Empty;

    public IndexModel(ILogger<IndexModel> logger, IMessageSender messageSender)
    {
        _logger = logger;
        _messageSender = messageSender;

        _kits = Data.GenerateKits();
        _works = Data.GenerateWorks();
    }

    public async Task OnPostAsync(int serviceId, string user, string service, string contact, string question)
    {
        try
        {
            var serviceTag = GetServiceTag(serviceId, service);
            var message = new StringBuilder()
                .AppendLine("Новый возможный заказ (Цены)")
                .AppendLine($"Клиент: {user}")
                .AppendLine($"Контакт: {contact}")
                .AppendLine($"{serviceTag}: {service}")
                .AppendLine($"Вопрос от клиента: {question}").ToString();

            await _messageSender.SendAsync(message);

            OrderInformation = Consts.OrderInformation;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

    private string GetServiceTag(int serviceId, string service)
    {
        var siteServiceList = Kits.Concat(Works);
        var kitOrWork = siteServiceList.FirstOrDefault(x => (x.Id == serviceId && x.Name.ToLower() == service.ToLower()) || x.Name.ToLower() == service.ToLower());
        if (kitOrWork != null)
        {
            return $"Услуга из списка сайта (стоимость - от {kitOrWork.Price} {Currency})";
        }
        else
        {
            return "Услуга вне списка сайта";
        }
    }
}
