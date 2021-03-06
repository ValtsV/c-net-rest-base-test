using Microsoft.EntityFrameworkCore;
using dot_net_backend_test.DataAccess;
using dot_net_backend_test.Services;
using dot_net_backend_test.Services.Implementation;
using dot_net_backend_test;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// serilog
builder.Host.UseSerilog((hostBuilderCtx, loggerConf) =>
{
    loggerConf
    .WriteTo.Console()
    .WriteTo.Debug()
    .ReadFrom.Configuration(hostBuilderCtx.Configuration);
});
    
const string CONNECTIONNAME = "TestDB";
var connectionstring = builder.Configuration.GetConnectionString(CONNECTIONNAME);


// Add services to the container.
builder.Services.AddDbContext<TestDBContext>(options => options.UseSqlServer(connectionstring));

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddJwtTokenServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddScoped<IServices, Services>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IThemeService, ThemeService>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer Scheme (username: Admin | password: admin) -> use Account Post method to get access token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
        
    });
});

// CORS (very open one)
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

var supportedCultures = new[] { "es-ES", "en-US", "de-DE", "fr-FR" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
