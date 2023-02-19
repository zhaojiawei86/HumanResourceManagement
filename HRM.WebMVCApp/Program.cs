using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.Infrastructure.Data;
using HRM.Infrastructure.Repository;
using HRM.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HRMDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("HrmDb"));
});

var app = builder.Build();

// Dependency injection for repositories
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();

// Dependency injection for services
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

