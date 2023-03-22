namespace CarWrapFilm.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureMiddlewares(this WebApplication @this)
    {
        if (!@this.Environment.IsDevelopment())
        {
            @this.UseExceptionHandler("/Error");
            @this.UseHsts();
        }
        @this.UseHttpsRedirection();
        @this.UseStaticFiles();
        @this.UseRouting();
        @this.UseAuthorization();

        return @this;
    }

    public static WebApplication ConfigureRoutes(this WebApplication @this)
    {
        @this.MapRazorPages();

        return @this;
    }
}
