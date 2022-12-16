using ArandaPrueba.Infraestructure;
using ArandaPrueba.Core.Interfaces;
using ArandaPrueba.Core.Services;
using ArandaPrueba.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuracion conexion a la base de datos
builder.Services.AddDbContext<ArandaDBContext>(x =>
    x.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:ArandaDB")));

// Dependencias - Inyeccion de dependencias
builder.Services.AddTransient<ITbCategoriaRepository, TbCategoriaRepository>();
builder.Services.AddTransient<ITbCategoriaService, TbCategoriaService>();
builder.Services.AddTransient<ITbProductosRepository, TbProductosRepository>();
builder.Services.AddTransient<ITbProductosService, TbProductosService>();

//Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArandaPrueba.Api", Version = "v1" });
});

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