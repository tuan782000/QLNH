using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using QLNH_Web_APIs.Data;
using QLNH_Web_APIs.Mappings;


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

        // Auto Mapper Configurations
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Test API",
                Description = "ASP.NET Core Web API"
            });

            // Cấu hình Swagger để sử dụng tệp XML
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            // Kiểm tra tệp XML tồn tại và thêm vào Swagger
            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath);
            }
        });

        // Các dịch vụ khác
        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost", builder =>
                //builder.WithOrigins("http://localhost:5173") // Thêm nguồn frontend cho phép
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        // app.UseSwaggerUI(c =>
        // {
        //     c.SwaggerEndpoint("../swagger/v1/swagger.json", "Test API V1");
        // });

        app.UseSwaggerUI(options =>
  {
      // Chỉ định endpoint Swagger JSON
      options.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");

      // Đặt Swagger UI tại đường dẫn bạn muốn
      options.RoutePrefix = "swagger";  // Nếu muốn giữ nguyên "swagger" như URL
                                        // Hoặc thay đổi thành một đường dẫn tùy chỉnh
      options.RoutePrefix = string.Empty; // Swagger UI sẽ mở tại / (root URL)
  });

        app.UseHttpsRedirection();

        app.UseCors("AllowLocalhost"); // Sử dụng chính sách CORS

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

