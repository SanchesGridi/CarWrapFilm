using CarWrapFilm.Extensions;

var app = WebApplication.CreateBuilder(args).ConfigureServices().Build();
app.ConfigureMiddlewares().ConfigureRoutes().Run();
