using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data;
using Proyecto_Zetta.Server.Repositorio;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//DEPLOY CONFIG
var port = Environment.GetEnvironmentVariable("PORT") ?? "8888";
builder.WebHost.UseUrls($"http:// *: {port}");

builder.Services.AddHealthChecks();
//


// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));



builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IObraRepositorio, ObraRepositorio>();
builder.Services.AddScoped<IInstaladorRepositorio, InstaladorRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<ISeguimientoRepositorio, SeguimientoRepositorio>();
builder.Services.AddScoped<IFormadePagoRepositorio, FormadePagoRepositorio>();
builder.Services.AddScoped<IMaterialRepositorio, MaterialRepositorio>();
builder.Services.AddScoped<IMantenimientoRepositorio, MantenimientoRepositorio>();
builder.Services.AddScoped<IItemTipoRepositorio, ItemTipoRepositorio>();

var app = builder.Build();

//DEPLOY CONFIG
app.UseHealthChecks("/health");
//


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
