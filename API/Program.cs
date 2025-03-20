using backend.Data;
using backend.Exceptions;
using backend.GRPC.Client;
using backend.Repositories.Booking;
using backend.Repositories.Guest;
using backend.Repositories.Hotel;
using backend.Repositories.Room;
using backend.Services.Booking;
using backend.Services.Guest;
using backend.Services.Hotel;
using backend.Services.Room;
using GrpcClientSettings = backend.GRPC.Client.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>();

// Add Repositories
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// Add Services
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();

// gRPC Clients
builder.Services.AddSingleton<ClientGrpcChannel>();
builder.Services.AddSingleton<EmailNotificationClient>();

// Add Exception Handler
builder.Services.AddSingleton<ExceptionHandlingMiddleware>();

// Add Settings
builder.Configuration.AddJsonFile("GRPC/Client/settings.json", optional: false, reloadOnChange: true);
builder.Services.Configure<GrpcClientSettings>(builder.Configuration.GetSection("GrpcClientSettings"));

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
