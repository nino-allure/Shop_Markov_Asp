using Shop_Markov.Data.Interfaces;
using Shop_Markov.Data.Mocks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICategories, MockCategories>();
builder.Services.AddTransient<IItems, MockItmes>();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.Run();