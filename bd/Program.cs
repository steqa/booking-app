using bd.Data;
using bd.Exceptions;
using bd.Repositories.Guest;
using bd.Repositories.Hotel;
using bd.Services.Guest;
using bd.Services.Hotel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>();

// Add Repositories
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

// Add Services
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IHotelService, HotelService>();

// Add Exception Handler
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

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
