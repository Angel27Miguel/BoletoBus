using BoletoBus.Web.Service.Empleado;
using BoletoBus.Web.Service.Reserva;
using BoletoBus.Web.Service.Viaje;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddTransient<IEmpleadoService, EmpleadoService>();

builder.Services.AddTransient<IReservaService, ReservaService>();

builder.Services.AddTransient<IViajeServices, ViajeService>();

//builder.Services.AddTransient<IEmpleadoService, EmpleadoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
