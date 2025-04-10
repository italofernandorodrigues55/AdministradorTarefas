using AdministradorTarefas.Domain.Entities;
using AdministradorTarefas.Util.Enums;

namespace AdministradorTarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> BuscarAsync(StatusTarefa status);
        Task<Tarefa> BuscarPorId(int id);
        Task InserirAsync(Tarefa tarefa);
        Task AtualizarAsync(Tarefa tarefa);
        Task ExcluirAsync(int id);
    }
}
