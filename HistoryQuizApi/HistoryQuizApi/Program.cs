
using HistoryQuizApi.Repository.Implement;
using HistoryQuizApi.Repository.Interface;
using HistoryQuizApi.Services.Implement;
using HistoryQuizApi.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System;

var builder = WebApplication.CreateBuilder(args);


//lay chuoi ket noi tu appseting.json
var configuration = builder.Configuration;
string connectionString = configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ??ng ký các service và repository
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IClassHistoryRepository, ClassHistoryRepository>();
builder.Services.AddScoped<IClassHistoryService, ClassHistoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


builder.Services.AddControllers();
builder.Services.AddControllers();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
