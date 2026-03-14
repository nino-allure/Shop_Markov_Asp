using Shop_Markov.Data.Interfaces;
using Shop_Markov.Data.Mocks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.Run();

public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ICategories, MockCategories>();
    services.AddTransient<IItems, MockItmes>();

    services.AddMvc(option => option.EnableEndpointRouting = false);
}