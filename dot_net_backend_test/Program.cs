using Microsoft.EntityFrameworkCore;
using dot_net_backend_test.DataAccess;
using dot_net_backend_test.Services;

var builder = WebApplication.CreateBuilder(args);
    
const string CONNECTIONNAME = "TestDB";
var connectionstring = builder.Configuration.GetConnectionString(CONNECTIONNAME);


// Add services to the container.
builder.Services.AddDbContext<TestDBContext>(options => options.UseSqlServer(connectionstring));

builder.Services.AddControllers();

builder.Services.AddScoped<IServices, Services>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
