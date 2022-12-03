using Microsoft.EntityFrameworkCore;
using TODO_MVC_NETCORE.Models;
using TODO_MVC_NETCORE.Servicios;
using TODO_MVC_NETCORE.Servicios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IContacto, ContactoServices>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=AGENDA-TELEFONICA;Integrated Security=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
