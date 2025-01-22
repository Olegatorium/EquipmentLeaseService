using EquipmentLeaseService.API.BackgroundProcessing;
using EquipmentLeaseService.API.Middleware;
using EquipmentLeaseService.Core.BackgroundProcessingContract;
using EquipmentLeaseService.Core.Domain.RepositoryContracts;
using EquipmentLeaseService.Core.Mappings;
using EquipmentLeaseService.Core.ServiceContracts;
using EquipmentLeaseService.Core.Services;
using EquipmentLeaseService.Infrastructure.BackgroundProcessing;
using EquipmentLeaseService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IContractRequestsService, ContractRequestsService>();
builder.Services.AddScoped<IContractRequestsRepository, ContractRequestsRepository>();

builder.Services.AddSingleton<IApiKeyService, ApiKeyService>();

builder.Services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
builder.Services.AddHostedService<BackgroundTaskProcessor>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/EquipmentLeaseService_Log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "API Key needed to access the endpoints. X-Api-Key: {key}",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "X-Api-Key",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ApiKeyMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();


app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
