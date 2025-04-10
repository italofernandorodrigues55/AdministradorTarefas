using AdministradorTarefas.Application.DTOs.Tarefa;
using FluentValidation;

public class TarefaAtualizacaoDTOValidator : AbstractValidator<TarefaAtualizacaoDTO>
{
    public TarefaAtualizacaoDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome � obrigat�rio.")
            .MaximumLength(100).WithMessage("Nome deve ter no m�ximo 100 caracteres.");

        RuleFor(x => x.Status)
            .NotNull().WithMessage("Status � obrigat�rio.");
    }
}