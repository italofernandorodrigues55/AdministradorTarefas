using AdministradorTarefas.Application.DTOs.Tarefa;
using AdministradorTarefas.Domain.Entities;
using AutoMapper;

namespace AdministradorTarefas.Application.Mappings;

public class EntitiesToDTOMappingProfile : Profile
{
    public EntitiesToDTOMappingProfile()
    {
        CreateMap<Tarefa, TarefaRetornoDTO>();
        CreateMap<TarefaCriacaoDTO, Tarefa>();
        CreateMap<TarefaAtualizacaoDTO, Tarefa>();
    }
}
