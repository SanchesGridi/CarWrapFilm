namespace CarWrapFilm.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder @this)
    {
        var services = @this.Services;

        services.AddRazorPages();

        return @this;
    }
}
