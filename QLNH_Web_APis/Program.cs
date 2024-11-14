var builder = WebApplication.CreateBuilder(args);

// Khởi tạo lớp Startup
var startup = new Startup(builder.Configuration);

// Gọi ConfigureServices từ Startup
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Gọi Configure từ Startup
startup.Configure(app, app.Environment);

app.Run();
