namespace CarWrapFilm.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder @this)
    {
        var services = @this.Services;
        var configuration = @this.Configuration;
        var environment = @this.Environment;

        services.AddTelegramDependency(configuration, environment).AddRazorPages();

        return @this;
    }
}
