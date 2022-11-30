using CarRentAPI.Application.Interfaces;
using CarRentAPI.Application.Services;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;
using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarRentDbContext>();

//builder.Services.AddDbContext<CarRentDbContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("ConnString"))
//    );
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IGenericRepository<Car>, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddScoped<IGenericRepository<RentalPlace>, RentalPlaceRepository>();
builder.Services.AddScoped<IRentalPlace, RentalPlaceRepository>();

builder.Services.AddScoped<IGenericRepository<Reservation>, ReservationRepository>();
builder.Services.AddScoped<IReservation, ReservationRepository>();

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
