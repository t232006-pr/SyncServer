using Microsoft.EntityFrameworkCore;
using SyncServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Подключение к PostgreSQL
var connectionString =
    Environment.GetEnvironmentVariable("CONNECTION_STRING") ??  // Облако (Cloud Run)
    builder.Configuration.GetConnectionString("DefaultConnection") ??  // Локально (appsettings.json)
    throw new InvalidOperationException("CONNECTION_STRING не установлена!");

builder.Services.AddDbContext<SyncDBContext>(options =>
    options.UseNpgsql(connectionString)
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Автоматически применить миграции при запуске
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SyncDBContext>();
    try
    {
        await db.Database.MigrateAsync();
        Console.WriteLine("✅ Миграции успешно применены!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Ошибка при применении миграций: {ex.Message}");
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();