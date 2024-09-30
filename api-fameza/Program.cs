using api_fameza.Models;
using api_fameza.Security;
using api_fameza.Security.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 1) Configuracion para la conexion de la BD creada en sql

builder.Services.AddDbContext<DbFarmaciaContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

// 2) Establecer las reglas cors para poder configurar la api desde cualquier dominio

var misReglasCors = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: misReglasCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// 3) Inyecciones de dependencias

builder.Services.AddScoped<IAuthService,AuthService>();

// 6) Inyecci�n de AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(misReglasCors);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
