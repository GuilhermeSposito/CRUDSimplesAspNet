using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TesteDeCriacaoDeApi1.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(
    options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string? PostgresConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(PostgresConnection));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
