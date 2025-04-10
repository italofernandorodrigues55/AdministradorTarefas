using AdministradorTarefas.Application.DTOs.Tarefa;
using FluentValidation;

namespace AdministradorTarefas.API.Validators;

public class TarefaCriacaoDTOValidator : AbstractValidator<TarefaCriacaoDTO>
{
    public TarefaCriacaoDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");
    }
}
