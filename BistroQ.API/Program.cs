using Microsoft.EntityFrameworkCore;
using BistroQ.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddDbContext<BistroQContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();