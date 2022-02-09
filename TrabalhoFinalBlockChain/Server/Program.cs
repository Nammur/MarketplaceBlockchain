using Itens.Services;
using TrabalhoFinalBlockChain.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using Itens.Repository;
using Itens.Infra;
using Players.Services;
using Players.Infra;
using Players.Repository;
using Transferencias.Services;
using Transferencias.Repository;
using Transferencias.Infra;
using Blazored.Modal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var dataContext = SqlServerDataContext.Create(builder.Configuration.GetConnectionString("TrabalhoFinalBlockChain"));

builder.Services.AddScoped(x => dataContext);

builder.Services.AddScoped<ItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<PlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<TransferenciaService, TransferenciaService>();
builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
