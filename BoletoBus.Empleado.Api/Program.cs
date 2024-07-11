using BoletoBus.Empleado.Domain.Interfaces;
using BoletoBus.Empleado.Persistance.Context;
using BoletoBus.Empleado.Persistance.Repositories;
using BoletoBus.Empleado.IOC.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BoletoBusContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BoletoBusContext")));

//Agregar depemdencia
//builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddEmpleadoDependencies();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
