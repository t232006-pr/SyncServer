using Microsoft.EntityFrameworkCore;
using SyncServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Подключение к PostgreSQL
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
    ?? throw new InvalidOperationException("CONNECTION_STRING не установлена!");

builder.Services.AddDbContext<SyncDBContext>(options =>
    options.UseNpgsql(connectionString)
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 


var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();