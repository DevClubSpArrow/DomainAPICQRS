using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using HindalcoBackend.Domain.Interface;
using HindalcoBackend.Business.Service;
using HindalcoBackend.Application;
using HindalcoBackend.API;
using HindalcoBackend.Business;
using System;
using System.Reflection;
using HindalcoBackend.Application.Interface;
using HindalcoBackend.Application.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
builder.Services.AddDbContext<appDBontext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("AuditAPIConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddMediatR(typeof(HindalcoBackend.Application.TokenGenerator).Assembly);
builder.Services.AddScoped<IBusiness, HindalcoBackend.Application.Service.AuditManager>();

//builder.Services.AddScoped<HindalcoBackend.Domain.Interface.ITokenGenerator, AuditManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.I
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
app.MapControllers();
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
