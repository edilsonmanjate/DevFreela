using DevFreela.API.Filters;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Validators;
using DevFreela.Core.Respositories;
using DevFreela.Infrastruture.Persistence;
using DevFreela.Infrastruture.Persistence.Repositories;

using FluentValidation.AspNetCore;

using MediatR;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

var connectionString = builder.Configuration.GetConnectionString("DevFreelaCsHome");
builder.Services.AddDbContext<DevFreelaDbContext>(options =>options.UseSqlServer(connectionString));

//builder.Services.AddScoped<IProjectService, ProjectService>();
//builder.Services.AddScoped<ISkillService, SkillService>();
//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

//builder.Services.AddMediatR(typeof(CreateProjectCommand));
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
