using bistro_q_api.Data;
// using AutoMapper;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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