using Microsoft.EntityFrameworkCore;
using dot_net_backend_test.DataAccess;
using dot_net_backend_test.Services;
using dot_net_backend_test.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
    
const string CONNECTIONNAME = "TestDB";
var connectionstring = builder.Configuration.GetConnectionString(CONNECTIONNAME);


// Add services to the container.
builder.Services.AddDbContext<TestDBContext>(options => options.UseSqlServer(connectionstring));

builder.Services.AddJwtTokenServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddScoped<IServices, Services>();
builder.Services.AddScoped<IStudentService, StudentService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
