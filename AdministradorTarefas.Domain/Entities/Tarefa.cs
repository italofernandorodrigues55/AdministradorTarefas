using AdministradorTarefas.Util.Enums;
using AdministradorTarefas.Util.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorTarefas.Domain.Entities;

[Table("TAREFA")]
public partial class Tarefa
{
    [Key]
    [Column("id")]
    public int Id { get; private set; }

    [Required]
    [Column("nome")]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Column("descricao")]
    [MaxLength(200)]
    public string Descricao { get; set; }

    [Column("responsavel")]
    [MaxLength(100)]
    public string Responsavel { get; set; }

    [Required]
    [Column("data_abertura")]
    public DateTime DataAbertura { get; private set; }

    [Required]
    [Column("status")]
    public StatusTarefa Status { get; set; }


    public Tarefa(string nome, string descricao, string responsavel)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new DomainException("Nome é obrigatório.");

        Nome = nome;
        Descricao = descricao;
        Responsavel = responsavel;
        DataAbertura = DateTime.Now.ToUniversalTime();
        Status = StatusTarefa.Novo;
    }
}
