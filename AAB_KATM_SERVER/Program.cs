global using AAB_KATM_SERVER.Configuration;
using AAB_KATM_SERVER.DTOs.Clients;
using AAB_KATM_SERVER.Entities;
using AAB_KATM_SERVER.Repositories;
using AAB_KATM_SERVER.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Repositories
builder.Services.AddTransient<IClientRepository, ClientRepository>();
#endregion

#region Fluent Validation
builder.Services.AddMvc().AddFluentValidation();

builder.Services.AddTransient<IValidator<ClientDTO>, ClientValidator>();
builder.Services.AddTransient<IValidator<ClientUpdateDTO>, ClientUpdateValidator>();

builder.Services.AddFluentValidationRulesToSwagger();
#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ApplicationContext>();

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
