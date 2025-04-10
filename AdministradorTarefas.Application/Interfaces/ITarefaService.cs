using AdministradorTarefas.Application.DTOs.Tarefa;
using AdministradorTarefas.Domain.Entities;
using AdministradorTarefas.Util.Enums;

namespace AdministradorTarefas.Application.Interfaces;

public interface ITarefaService
{
    Task<IEnumerable<TarefaRetornoDTO>> BuscarAsync(StatusTarefa status);
    Task<TarefaRetornoDTO> BuscarPorId(int id);
    Task<TarefaRetornoDTO?> InserirAsync(TarefaCriacaoDTO tarefa);
    Task AtualizarAsync(TarefaAtualizacaoDTO tarefa);
    Task ExcluirAsync(int id);
}
