using AutoMapper;
using BistroQ.API.Configurations;
using BistroQ.API.Hubs;
using BistroQ.API.Middlewares;
using BistroQ.Core.Mappings;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

builder.Services.AddDatabaseConfig()
    .AddApiConfig()
    .AddIdentityConfig()
    .AddAuthenticationConfig()
    .AddAppServiceConfig()
    .AddSwaggerConfig()
    .AddAutoMapperConfig()
    .AddAwsS3Config();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SignalRPolicy", policy =>
    {
        policy.SetIsOriginAllowed(origin => true) 
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddSignalR();

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
app.MapHub<CheckoutHub>("hubs/checkout");

app.Run();