using CarWrapFilm.Extensions;
using CarWrapFilm.Models;
using Telegram.Bot;

namespace CarWrapFilm.Services;

public class TelegramBotMessageSender : IMessageSender
{
    private readonly TelegramConfiguration _configuration;
    private readonly TelegramBotClient _botClient;

    public TelegramBotMessageSender(TelegramConfiguration configuration)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }
        if (configuration.Token.IsEmpty())
        {
            throw new ArgumentException($"Telegram [{nameof(configuration.Token)}] was empty!");
        }
        if (configuration.Users.IsEmpty())
        {
            throw new ArgumentException($"Telegram [{nameof(configuration.Users)}] list was empty!");
        }

        _configuration = configuration;
        _botClient = new TelegramBotClient(_configuration.Token);
    }

    public async Task SendAsync(string message)
    {
        foreach (var user in _configuration.Users)
        {
            await _botClient.SendTextMessageAsync(user.ChatId, message);
        }
    }
}
