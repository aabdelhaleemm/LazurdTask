using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Lazurdit.Application;
using Lazurdit.Application.Validators;
using Lazurdit.Infrastructure;
using Lazurdit.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureDependency();
builder.Services.AddApplicationDependency();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", x =>
    {
        
        x.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var app = builder.Build();

//Seeding
using (var scope = app.Services.CreateScope())
{
    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seedingService.Seed();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAny");
app.UseAuthorization();

app.MapControllers();

app.Run();