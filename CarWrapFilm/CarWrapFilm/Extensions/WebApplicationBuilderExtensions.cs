using CarWrapFilm.Models;
using CarWrapFilm.Services;

namespace CarWrapFilm.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder @this)
    {
        var services = @this.Services;
        var configuration = @this.Configuration;

        var token = configuration.GetSection("Telegram:BotToken").Value;
        var users = new List<TelegramUser>
        {
            new TelegramUser(
                configuration.GetSection("Telegram:Users:AlexGrid:Name").Value,
                configuration.GetSection("Telegram:Users:AlexGrid:ChatId").Value.ToLong()
            ),
            new TelegramUser(
                configuration.GetSection("Telegram:Users:SergDerg:Name").Value,
                configuration.GetSection("Telegram:Users:SergDerg:ChatId").Value.ToLong()
            )
        };
        var telegramConfiguration = new TelegramConfiguration(token, users);

        services.AddScoped<IMessageSender, TelegramBotMessageSender>(_ => new(telegramConfiguration));
        services.AddRazorPages();

        return @this;
    }
}
