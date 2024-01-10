using Infra.Data.Contex;
using Infra.Ioc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Data Base
#region Config DataBase

builder.Services.AddDbContext<ApplicationDbContxt>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDB"));
});
#endregion
//Ioc Dependency
#region Dependency Injection IoC

DependencyContainer.RegisterServices(builder.Services);

#endregion


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
