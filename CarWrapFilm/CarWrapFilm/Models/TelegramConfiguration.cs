namespace CarWrapFilm.Models;

public record TelegramConfiguration(string Token, List<TelegramUser> Users);
