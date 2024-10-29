using AutoMapper;
using BistroQ.API.Configurations;
using BistroQ.API.Middlewares;
using BistroQ.Core.Mappings;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

builder.Services.AddDatabaseConfig()
    .AddApiConfig()
    .AddAutoMapperConfig()
    .AddIdentityConfig()
    .AddSwaggerConfig()
    .AddAuthenticationConfig()
    .AddAppServiceConfig();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlingMiddleware();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();