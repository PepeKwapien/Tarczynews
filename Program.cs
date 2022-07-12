using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tarczynews.Data;
using Tarczynews.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Old way of accessing data before using repositories
/*builder.Services.AddSingleton<IDataAccess>(da => new TarczynCapContext((new DbContextOptionsBuilder<TarczynCapContext>())
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).Options));*/

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITarczynCapRepository, TarczynCapRepository>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
