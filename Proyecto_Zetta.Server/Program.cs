using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.Server.Repositorio;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// DEPLOY CONFIG
var port = Environment.GetEnvironmentVariable("PORT") ?? "7201";
builder.WebHost.UseUrls($"https://*:{port}");

builder.Services.AddHealthChecks();
//

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});

// Database context configuration
builder.Services.AddDbContext<Context>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("conn"))); // Usar el connection string del archivo de configuración

builder.Services.AddAutoMapper(typeof(Program));

// Repositories
builder.Services.AddScoped<IObraRepositorio, ObraRepositorio>();
builder.Services.AddScoped<IInstaladorRepositorio, InstaladorRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<ISeguimientoRepositorio, SeguimientoRepositorio>();
builder.Services.AddScoped<IFormadePagoRepositorio, FormadePagoRepositorio>();
builder.Services.AddScoped<IMaterialRepositorio, MaterialRepositorio>();
builder.Services.AddScoped<IMantenimientoRepositorio, MantenimientoRepositorio>();
builder.Services.AddScoped<IItemTipoRepositorio, ItemTipoRepositorio>();
builder.Services.AddScoped<IPresupuestoRepositorio, PresupuestoRepositorio>();

var app = builder.Build();

// DEPLOY CONFIG
app.UseHealthChecks("/health");
//

// Configure CORS
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
