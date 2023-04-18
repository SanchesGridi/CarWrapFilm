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

        public string Title => "�����������";
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
                    .AppendLine("����� ��������� ����� (�����������)")
                    .AppendLine($"������: {user}")
                    .AppendLine($"�������: {contact}")
                    .AppendLine("��������� ������:");
                for (var index = 0; index < works.Length; index++)
                {
                    builder.AppendLine($"{index +1}) {works[index].Name} (��������� - {works[index].Price}) [{works[index].Count} ���.]");
                }
                builder.AppendLine($"������ �� �������: {question}");

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
