
using ClientProductApp.InfrastructureLayer.Data.Contexts;
using ClientProductApp.InfrastructureLayer.Repository;
using Microsoft.EntityFrameworkCore;
using ClientProductApp.DomainLayer.Interfaces;
using ClientProductApp.Applicationlayer.MapperProfiles;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Register Generic Repository
builder.Services.AddTransient(typeof(IGenericRepository<>),typeof( GenericRepository<>));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//builder.Services.AddTransient<ModelStateValidator>();

builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Handle 404 errors
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 404)
    {
        context.HttpContext.Response.Redirect("/Notfound");
    }
});

app.Run();
