using Microsoft.EntityFrameworkCore;
using PanteonApi.Application.Services;
using PanteonApi.Domain.Infra.Interfaces;
using PanteonApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConStr"));
});

//Configure MongoDv settings and services
builder.Services.Configure<PanteonDatabaseSettings>(builder.Configuration.GetSection("MongoDB"));

//Singleton
builder.Services.AddSingleton<IBuildingConfigurationRepository, BuildingConfigurationRepository>();
builder.Services.AddSingleton<IConfigurationRepository, ConfigurationRepository>();
builder.Services.AddSingleton<IParameterDefinitionRepository, ParameterDefinitionRepository>();
builder.Services.AddSingleton<IParameterGroupRepository, ParameterGroupRepository>();

//Scoped
builder.Services.AddScoped<IBuildingConfigurationService, BuildingConfigurationService>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.AddScoped<IParameterDefinitionService, ParameterDefinitionService>();
builder.Services.AddScoped<IParameterGroupService, ParameterGroupService>();
builder.Services.AddScoped<ITokenService, TokenService>();

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS policy
app.UseCors("AllowAll");

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
