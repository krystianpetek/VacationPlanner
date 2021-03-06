using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VacationPlannerAPI.Database;
using VacationPlannerAPI.Services;

const string ApiKeyName = "ApiKey";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<VacationPlannerDbContext>(config =>
    config.UseSqlServer(builder.Configuration.GetConnectionString("VP_DbContext")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VacationPlannerAPI", Version = "1.0" });

    c.AddSecurityDefinition(ApiKeyName, new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = ApiKeyName,
        Type = SecuritySchemeType.ApiKey,
        Description = "Prosze poda? klucz: mojSekretnyKluczAPI"
    });

    var key = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = ApiKeyName
        },
        In = ParameterLocation.Header
    };

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                key, new List<string>()
            }
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("https://localhost:7020");