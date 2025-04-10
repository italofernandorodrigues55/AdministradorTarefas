using AdministradorTarefas.Util.Enums;

namespace AdministradorTarefas.Application.DTOs.Tarefa;

public record TarefaRetornoDTO
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string Descricao { get; init; } = string.Empty;
    public string Responsavel { get; init; } = string.Empty;
    public DateTime DataAbertura { get; init; }
    public StatusTarefa Status { get; init; }
}
