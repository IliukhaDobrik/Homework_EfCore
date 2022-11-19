using DataLayer.Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDatabase(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute("default",
                       "{controller=Home}/{action=Index}/{id?}");

app.Run();