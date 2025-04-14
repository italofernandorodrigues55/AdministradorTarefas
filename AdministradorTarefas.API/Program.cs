using AdministradorTarefas.API.Middlewares;
using AdministradorTarefas.API.Utilities;
using AdministradorTarefas.Infra.Data.Context;
using AdministradorTarefas.Infra.Ioc;
using AdministradorTarefas.Util.Converters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("*")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
        options.JsonSerializerOptions.Converters.Add(new NullableDateTimeConverter());
    });

builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values
            .SelectMany(x => x.Errors)
            .Select(x => x.ErrorMessage);

        return new BadRequestObjectResult(new ResultViewModel(false, "Erro de validação", errors));
    };
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdministradorTarefas API V1");
    c.RoutePrefix = "swagger";
});

app.UseExceptionMiddleware();
app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.MapControllers();
app.Run();
public partial class Program { }
