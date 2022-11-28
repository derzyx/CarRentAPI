using CarRentAPI.Application.Interfaces;
using CarRentAPI.Application.Services;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarRentDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConnString"))
    );
builder.Services.AddScoped<ICustomService<Car>, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddScoped<ICustomService<RentalPlace>, RentalPlaceRepository>();
builder.Services.AddScoped<IRentalPlaceService, RentalPlaceRepository>();

builder.Services.AddScoped<ICustomService<Reservation>, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationRepository>();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<IValidationService, ValidationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
