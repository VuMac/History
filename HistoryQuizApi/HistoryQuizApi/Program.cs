
using HistoryQuizApi.Repository.Implement;
using HistoryQuizApi.Repository.Interface;
using HistoryQuizApi.Services.Implement;
using HistoryQuizApi.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API for my app"
    });
});

// Thêm dịch vụ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Thay đổi nếu cần
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
//cau hinh jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
// Thêm Authorization
builder.Services.AddAuthorization();


//lay chuoi ket noi tu appseting.json
var configuration = builder.Configuration;
string connectionString = configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();

// dang ký các service và repository
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClassHistoryRepository, ClassHistoryRepository>();
builder.Services.AddScoped<IClassHistoryService, ClassHistoryService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IExamService, ExamService>();

builder.Services.AddScoped<ILessonCompletionRepository, LessonCompletionRepository>();
builder.Services.AddScoped<ILessonCompletionService, LessonCompletionService>();

builder.Services.AddScoped<JwtService>();
//
//deploy lan network
builder.WebHost.UseKestrel()
               .UseUrls("https://0.0.0.0:5000"); // L?ng nghe trên t?t c? các IP và c?ng 5000

var app = builder.Build();
// Kích hoạt Swagger trong môi trường phát triển
if (app.Environment.IsProduction())
{
    app.UseSwagger(); // Đảm bảo bạn gọi UseSwagger()

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = "swagger"; // Chỉ định đường dẫn Swagger UI
    });
}
app.UseHttpsRedirection();

// Kích ho?t Authentication và Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAngularApp");
app.Run();
