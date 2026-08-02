using Microsoft.EntityFrameworkCore;
using WebAPIClinica.Models;

var builder = WebApplication.CreateBuilder(args);

// recuperar la cadena de conexion del appsettings.json
var cadena = builder.Configuration.GetConnectionString("cn1");

// registrar como servicio el contexto del EntityFrameworkCore
// builder.Services.AddDbContext<nombre_contexto>(opciones);
builder.Services.AddDbContext<Bdclinica2026WebapiContext>(
    opt => opt.UseSqlServer(cadena));
//

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
