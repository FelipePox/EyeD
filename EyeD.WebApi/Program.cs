using EyeD.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding database configuration
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Adding Swagger Configuration
builder.Services.AddSwaggerConfiguration();

// Adding JWT Auth Scheme Configuration
builder.Services.AddJwtConfiguration();

// Adding AutoMapper Configuration
builder.Services.AddAutoMapperConfiguration();

// Resolving Dependency Injection
builder.Services.AddDependencyInjectionConfiguration();



var app = builder.Build();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
