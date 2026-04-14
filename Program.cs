using Microsoft.EntityFrameworkCore;
using PotteryAPI.Data; // Убедитесь, что пространство имен указано верно!

var builder = WebApplication.CreateBuilder(args);

// 1. Регистрируем DbContext (ваш "мост" к БД)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Добавляем сервисы контроллеров и API Explorer (ОБЯЗАТЕЛЬНО!)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // <-- ЭТА СТРОКА КЛЮЧЕВАЯ ДЛЯ SWAGGER
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Urls.Add("http://*:8080"); // <-- Добавьте эту строку

// 3. Настраиваем конвейер middleware (порядок важен!)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      // <-- Включает генерацию Swagger-документации
    app.UseSwaggerUI();    // <-- Включает красивый UI-интерфейс
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 4. Ключевой момент! Подключаем маршрутизацию для контроллеров
app.MapControllers(); // <-- БЕЗ ЭТОГО SWAGGER НЕ УВИДИТ КОНТРОЛЛЕРЫ!

var dbPath = "/data/potteryshop.db";
if (!File.Exists(dbPath))
{
    var sourceDb = Path.Combine(AppContext.BaseDirectory, "Data", "potteryshop.db");
    if (File.Exists(sourceDb))
    {
        Directory.CreateDirectory("/data");
        File.Copy(sourceDb, dbPath);
    }
}

app.Run();