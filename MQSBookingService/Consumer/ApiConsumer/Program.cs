using Adapter.SQL;
using Adapter.SQL.Repositories;
using Application.Booking;
using Application.Booking.Ports;
using Application.Guest;
using Application.Guest.Ports;
using Application.Payment;
using Application.Payment.Ports;
using Application.Room;
using Application.Room.Ports;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using PaymentsApplication;
using PaymentsApplications.MercadoPago;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// IoC
builder.Services.AddScoped<IGuestManager, GuestManager>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IRoomManager, RoomManager>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingManager, BookingManager>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IPaymentProcessorFactory, PaymentProcessorFactory>();


//Conexão com banco
var connectionString = builder.Configuration.GetConnectionString("Main");
builder.Services.AddDbContext<MQSDbContext>(
    options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(MQSDbContext).Assembly.FullName)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

