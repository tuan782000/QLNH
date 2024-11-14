using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QLNH_Web_APIs.Data;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Phương thức này được gọi bởi runtime để thêm các dịch vụ vào container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Cấu hình kết nối đến MySQL
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            
        // Cấu hình Swagger
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "QLNH Web APIs",
                Description = "API documentation for QLNH",
                TermsOfService = new Uri("https://example.com/terms")
            });
        });

        // Cấu hình cho API Endpoints
        services.AddEndpointsApiExplorer();
    }

    // Phương thức này được gọi bởi runtime để định cấu hình pipeline HTTP.
    // public void Configure(WebApplication app, IWebHostEnvironment env)
    // {
    //     if (env.IsDevelopment())
    //     {
    //         app.UseSwagger();
    //         app.UseSwaggerUI();
    //     }

    //     app.UseHttpsRedirection();
    // }

    // Phương thức này được gọi bởi runtime để định cấu hình pipeline HTTP.
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // Kích hoạt Swagger và Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                // Đặt Swagger UI tại đường dẫn gốc
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "QLNH Web APIs v1");
                options.RoutePrefix = string.Empty; // Swagger UI sẽ mở tại / (root URL)
            });
        }

        app.UseHttpsRedirection();
    }
}
