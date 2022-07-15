using API.Domains;
using API.Interfaces;
using API.Models;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
//add data services
builder.Services.AddSingleton<IResourceDataService, ResourceDataService>();
builder.Services.AddSingleton<IClientDataServices, ClientDataService>();
builder.Services.AddSingleton<IProjectDataService,ProjectDataService>();
builder.Services.AddSingleton<ITaskDataService, TaskDataService>();
//add domains
builder.Services.AddSingleton<IResourceDomain, ResourceDomain>();
builder.Services.AddSingleton<IClientDomain, ClientDomain>();
builder.Services.AddSingleton<IProjectDomain, ProjectDomain>();
builder.Services.AddSingleton<ITaskDomain, TaskDomain>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Timesheet API",
        Description = "An API for all timesheet resources",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped(p =>
   p.GetRequiredService<IDbContextFactory<DatabaseContext>>().CreateDbContext());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
