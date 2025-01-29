using APIILearn;
using APIILearn.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataCon>(op => op.UseSqlServer("Server=localhost;Database=ApiiData;Trusted_Connection=True; TrustServerCertificate=True"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependance inversion
builder.Services.AddTransient<WeatherForecast>();     //send many new instance frm this class
builder.Services.AddScoped<WeatherForecast>();        //send just one instance over request  and ots Default
builder.Services.AddSingleton<WeatherForecast>();     // send just one instance over application 

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
