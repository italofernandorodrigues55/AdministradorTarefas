using AdministradorTarefas.Util.Enums;

namespace AdministradorTarefas.Application.DTOs.Tarefa
{
    public record TarefaAtualizacaoDTO(int Id, string Nome, string Descricao, string Responsavel, StatusTarefa Status);
}
