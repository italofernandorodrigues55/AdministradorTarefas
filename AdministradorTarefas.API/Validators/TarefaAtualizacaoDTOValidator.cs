using AdministradorTarefas.Application.DTOs.Tarefa;
using FluentValidation;

public class TarefaAtualizacaoDTOValidator : AbstractValidator<TarefaAtualizacaoDTO>
{
    public TarefaAtualizacaoDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Status)
            .NotNull().WithMessage("Status é obrigatório.");
    }
}