using CarWrapFilm.Extensions;
using CarWrapFilm.Models;
using CarWrapFilm.Services;
using CarWrapFilm.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace CarWrapFilm.Pages
{
    public class CalculatorModel : PageModel
    {
        private readonly ILogger<CalculatorModel> _logger;
        private readonly IMessageSender _messageSender;

        private readonly List<FilmWrappingKit> _works;

        public string Title => "Калькулятор";
        public string Currency => "BYN";
        public List<FilmWrappingKit> Works => _works;

        public string OrderInformation { get; set; } = string.Empty;

        public CalculatorModel(ILogger<CalculatorModel> logger, IMessageSender messageSender)
        {
            _logger = logger;
            _messageSender = messageSender;

            _works = Data.GenerateWorks();
        }

        public async Task OnPostAsync(WorkOrder[] works, string user, string contact, string question)
        {
            try
            {
                var builder = new StringBuilder()
                    .AppendLine("Новый возможный заказ (Калькулятор)")
                    .AppendLine($"Клиент: {user}")
                    .AppendLine($"Контакт: {contact}")
                    .AppendLine("Выбранные услуги:");

                var totalPrice = 0u;
                for (var index = 0; index < works.Length; index++)
                {
                    var name = works[index].Name;
                    var price = works[index].Price;
                    var count = works[index].Count;
                    totalPrice += price.Split(" ")[1].ToUint() * count;

                    builder.AppendLine($"{index +1}) {name} (стоимость - {price}) [{count} поз.]");
                }

                builder.AppendLine($"Итоговая стоимость: от {totalPrice} {Currency}");
                builder.AppendLine($"Вопрос от клиента: {question}");

                await _messageSender.SendAsync(builder.ToString());

                OrderInformation = Consts.OrderInformation;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
