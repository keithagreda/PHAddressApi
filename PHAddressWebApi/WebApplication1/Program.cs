using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PHAddressClassLibrary;
using PHAddressClassLibrary.Entities;
using PHAddressClassLibrary.Services;
using PHAddressWebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PHAddressDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
builder.Services.AddScoped<IAddress, Address>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
