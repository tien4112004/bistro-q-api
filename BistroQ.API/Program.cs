using AutoMapper;
using BistroQ.API.Configurations;
using BistroQ.API.Middlewares;
using BistroQ.Core.Mappings;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

builder.Services.AddDatabaseConfig();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddIdentityConfig()
    .AddAppServiceConfig();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
builder.Services.AddScoped<IMapper>(sp => new AutoMapper.Mapper(config));

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

app.MapControllers();

app.Run();