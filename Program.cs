using PokemonUmbraco;
using PokemonUmbraco.Services;
using PokemonUmbraco.Services.Interfaces;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<IPokeApiService, PokeApiService>(client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
});
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();
builder.Services.AddRazorPages();


builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddContentFinder<PokemonDetailsContentFinder>()
    .Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();
app.MapFallbackToPage("/app/{*path}", "/_Host");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

app.MapControllers();






await app.RunAsync();


