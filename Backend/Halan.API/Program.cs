using Flaminco.MinimalMediatR.Extensions;
using Halan.Application;
using Halan.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddModules<Program>();
builder.Services.AddApplicationDIContainer().AddInfrastructureDIContainer(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseCors("AllowLocalhost4200");

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI();
app.Run();
