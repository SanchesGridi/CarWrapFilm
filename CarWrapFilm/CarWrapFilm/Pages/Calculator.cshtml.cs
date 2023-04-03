using CarWrapFilm.Models;
using CarWrapFilm.Services;
using CarWrapFilm.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarWrapFilm.Pages
{
    public class CalculatorModel : PageModel
    {
        private readonly IMessageSender _messageSender;

        private readonly List<FilmWrappingKit> _works;

        public string Title => "Калькулятор";
        public string Currency => "BYN";
        public List<FilmWrappingKit> Works => _works;

        public CalculatorModel(IMessageSender messageSender)
        {
            _messageSender = messageSender;

            _works = Data.GenerateWorks();
        }
    }
}
