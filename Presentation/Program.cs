using Application.Interfaces;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Interfaces;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventsDatabaseConnection"))
);

var app = builder.Build();
app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Even Service API");
});

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
