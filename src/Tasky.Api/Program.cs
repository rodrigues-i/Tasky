using Microsoft.EntityFrameworkCore;
using Tasky.Api.Endpoints;
using Tasky.Api.Middlewares;
using Tasky.Application.Interfaces;
using Tasky.Application.Services;
using Tasky.Domain.Entities;
using Tasky.Domain.Interfaces;
using Tasky.Infrastructure.Persistence;
using Tasky.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();



app.MapProjectEndpoints();
app.MapTaskEndpoints();
//app.MapUerEndpoints();


app.Run();
