using Microsoft.EntityFrameworkCore;
using Timesheet_angular.Models;
using Timesheet_angular.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped(p =>
   p.GetRequiredService<IDbContextFactory<DatabaseContext>>().CreateDbContext());
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ProjectDataService>();
builder.Services.AddScoped<ClientDataService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.CommandTimeout(60));
}, ServiceLifetime.Scoped);

var app = builder.Build();

app.MapSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapControllerRoute(
    name: "project",
    pattern: "{controller}/{action}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
