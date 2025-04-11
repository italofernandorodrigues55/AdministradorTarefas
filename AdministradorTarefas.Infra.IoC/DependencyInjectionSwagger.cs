using AdministradorTarefas.Util.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace AdministradorTarefas.Infra.Ioc;

public static class DependencyInjectionSwagger
{
    public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AdministradorTarefas API",
                Version = "v1",
                Description = "Sistema de Administração de Tarefas"
            });

            c.MapType<StatusTarefa>(() => new OpenApiSchema
            {
                Type = "string",
                Enum = Enum.GetNames(typeof(StatusTarefa)).Select(name => (IOpenApiAny)new OpenApiString(name)).ToList()
            });
        });

        return services;
    }
}
