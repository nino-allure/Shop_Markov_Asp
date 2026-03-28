using Shop_Markov.Data.DataBase;
using Shop_Markov.Data.Interfaces;
using Shop_Markov.Data.Mocks;
using Shop_Markov.Data.Mocks.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICategories, DBCategory>();
builder.Services.AddTransient<IItems, DBItems>();
builder.Services.AddTransient<ItemsBasket>();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.Run();