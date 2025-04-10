using AdministradorTarefas.API.Utilities;
using AdministradorTarefas.Application.DTOs.Tarefa;
using AdministradorTarefas.Application.Interfaces;
using AdministradorTarefas.Domain.Entities;
using AdministradorTarefas.Util.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AdministradorTarefas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _tarefaService;

    public TarefaController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpGet("status/{status}")]
    [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarTarefas(StatusTarefa status)
    {
        var tarefas = await _tarefaService.BuscarAsync(status);
        return Ok(new ResultViewModel(true, "Tarefas listadas com sucesso", tarefas));
    }

    [HttpGet("{tarefaId}")]
    [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> BuscarTarefa(int tarefaId)
    {
        var tarefa = await _tarefaService.BuscarPorId(tarefaId);
        return Ok(new ResultViewModel(true, "Tarefa buscada com sucesso", tarefa));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CriarTarefa([FromBody] TarefaCriacaoDTO dto)
    {
        var tarefa = await _tarefaService.InserirAsync(dto);
        return CreatedAtAction(nameof(CriarTarefa), new { id = tarefa.Id },
                    new ResultViewModel(true, "Tarefa criada com sucesso", tarefa));
    }

    [HttpPut]
    [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> AtualizarTarefa([FromBody] TarefaAtualizacaoDTO dto)
    {
        await _tarefaService.AtualizarAsync(dto);
        return Ok(new ResultViewModel(true, "Tarefa alterada com sucesso"));
    }

    [HttpDelete("{tarefaId}")]
    [ProducesResponseType(typeof(ResultViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> ExcluirTarefa(int tarefaId)
    {
        await _tarefaService.ExcluirAsync(tarefaId);
        return Ok(new ResultViewModel(true, "Tarefa excluída com sucesso"));
    }
}
