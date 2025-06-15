//using backend01.Data;

using backend01.Reservations.Applications.Internal.Service;
using backend01.Scooter.Application.Internal.Service;
using backend01.Shared.Domain.Repositories;
using backend01.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend01.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend01.Suscriptions.Application.Internal.Service;
using backend01.Suscriptions.Domain.Model.Aggregate;
using backend01.Users.Application.Internal.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();     //Agregar
builder.Services.AddSwaggerGen();              //agregar

builder.Services.AddScoped<IScooterService, ScooterService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISuscriptionService, SuscriptionService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

// Add Datbabase Context

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});  // Para que se cree la base de datos


//builder.Services.AddOpenApi();               // Comentar

var app = builder.Build();

// Veryfy Database Object are created
using (var scope = app.Services.CreateScope())  // verifucar si exite el base de datos
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    var userService = services.GetRequiredService<IUserService>();

    context.Database.EnsureCreated();

    /*
     * // Crear usuario solo si no existe
    if (!context.Users.Any(u => u.Email == "velarde@gmail.com"))
    {
        var user = new backend01.Users.Domain.Model.Aggregate.User
        {
            Name = "Néstor Velarde",
            Phone = "987654321",
            Dni = "87654321",
            Email = "velarde@gmail.com",
            Password = userService.HashPassword("654321"),
            Photo = "https://i.ibb.co/8rdm6xC/Logo-Movi-Tech.png",
            Address = "Av. Metropolitana, Lima",
            RoleId = 3
        };
        // Obtener el máximo Id actual
        var maxId = context.Users.Any() ? context.Users.Max(u => u.Id) : 0;
        user.Id = maxId + 1;
        
        context.Users.Add(user);
        context.SaveChanges();
    }
     */
    if (!context.TypeSuscriptions.Any())
    {
        context.TypeSuscriptions.AddRange(
            new TypeSuscription { Name = "Plan Semanal", Costo = "29.90" },
            new TypeSuscription { Name = "Plan Mensual", Costo = "79.90" },
            new TypeSuscription { Name = "Plan Trimestral", Costo = "109.90" }
        );
        context.SaveChanges();
    }
}

app.UseSwagger();  // Agregar
app.UseSwaggerUI(); // Agregar

app.UseHttpsRedirection();

// este es un comentario para explicar que se debe agregar el CORS
app.UseRouting();


app.UseCors(builder =>
    builder.WithOrigins("http://localhost:5184")
        .AllowAnyHeader()
        .AllowAnyMethod());


app.UseAuthorization();
app.MapControllers();
app.Run();