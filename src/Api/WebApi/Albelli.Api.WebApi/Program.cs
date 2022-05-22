using Albelli.Api.Application.Abstract;
using Albelli.Api.Application.Concrete;
using Albelli.Api.Application.Extensions;
using Albelli.Api.WebApi.Middleware;
using Albelli.Infrastructure.Persistence.Extensions;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddlewareExtension>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
