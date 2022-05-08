global using VacationPlannerAPI.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using VacationPlannerAPI.Models;

const string ApiKeyName = "ApiKey";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<VP_DbContext>(config => config.UseSqlServer(builder.Configuration.GetConnectionString("VP_DbContext")));
//builder.Services.AddDbContext<VP_DbContext>(config => config.UseSqlite(builder.Configuration.GetConnectionString("VP_DbContext")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VacationPlannerAPI", Version = "1.0" });

    c.AddSecurityDefinition(ApiKeyName, new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Name = ApiKeyName,
        Type = SecuritySchemeType.ApiKey,
        Description = "Prosze poda� klucz: mojSekretnyKluczAPI",
    });

    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = ApiKeyName
        },
        In = ParameterLocation.Header
    };

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement()
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

app.Run();
