using CarWrapFilm.Models;
using CarWrapFilm.Services;

namespace CarWrapFilm.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramDependency(this IServiceCollection @this, ConfigurationManager configuration, IWebHostEnvironment environment)
    {
        var token = configuration.GetSection("Telegram:BotToken").Value;
        var users = new List<TelegramUser>
        {
            new(
                configuration.GetSection("Telegram:Users:AlexGrid:Name").Value,
                configuration.GetSection("Telegram:Users:AlexGrid:ChatId").Value.ToLong()
            )
        };
        if (!environment.IsDevelopment())
        {
            users.AddRange(new TelegramUser[]
            {
                new(
                    configuration.GetSection("Telegram:Users:SergDerg:Name").Value,
                    configuration.GetSection("Telegram:Users:SergDerg:ChatId").Value.ToLong()
                ),
                new(
                    configuration.GetSection("Telegram:Users:SergKisha:Name").Value,
                    configuration.GetSection("Telegram:Users:SergKisha:ChatId").Value.ToLong()
                )
            });
        }
        @this.AddScoped<IMessageSender, TelegramBotMessageSender>(_ => new(new(token, users)));

        return @this;
    }
}
