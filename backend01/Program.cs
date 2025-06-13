//using backend01.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();     //Agregar
builder.Services.AddSwaggerGen();              //agregar

// Add Datbabase Context
/*
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});
*/

//builder.Services.AddOpenApi();               // Comentar

var app = builder.Build();

// Veryfy Database Object are created

/*
using (var scope = app.Services.CreateScope())  // verifucar si exite el base de datos
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Ensure the database is created
}
*/
// Configure the HTTP request pipeline.  // comentar
/*if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}*/

app.UseSwagger();  // Agregar
app.UseSwaggerUI(); // Agregar


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();