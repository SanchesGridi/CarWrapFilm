namespace CarWrapFilm.Services;

public interface IMessageSender
{
    Task SendAsync(string message);
}
