using Microsoft.EntityFrameworkCore;
using AzureSQLWebAPIMicroservice.Data;
using AzureSQLWebAPIMicroservice.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllers();

//builder.AddSqlServerDbContext<ExampleDbContext>("sqldata");

builder.Services.AddDbContext<ExampleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqldata")));

builder.Services.AddScoped<ExampleModelService>();

// Add CORS policy (if needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7130") // Your Blazor app's URL
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();

// Add Swagger for API documentation (optional for development)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

using var scope = app.Services.CreateScope();

using var db = scope.ServiceProvider.GetRequiredService<ExampleDbContext>();

//var created = await db.Database.EnsureCreatedAsync();

//if (created)
//{
//    Console.WriteLine("Database created!");
//}

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use the defined CORS policy
app.UseCors("BlazorPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
