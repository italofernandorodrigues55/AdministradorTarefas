using System.ComponentModel;

namespace AdministradorTarefas.Util.Enums;

public enum StatusTarefa
{
    [Description("Todos")]
    Todos,

    [Description("Novo")]
    Novo,

    [Description("Ativo")]
    Ativo,

    [Description("Pendente")]
    Pendente,

    [Description("Concluído")]
    Concluido
}
