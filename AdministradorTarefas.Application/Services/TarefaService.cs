using AdministradorTarefas.Application.DTOs.Tarefa;
using AdministradorTarefas.Application.Interfaces;
using AdministradorTarefas.Domain.Entities;
using AdministradorTarefas.Domain.Interfaces;
using AdministradorTarefas.Util.Enums;
using AutoMapper;

namespace AdministradorTarefas.Application.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IMapper _mapper;

    public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper)
    {
        _tarefaRepository = tarefaRepository;
        _mapper = mapper;
    }

    public async Task AtualizarAsync(TarefaAtualizacaoDTO tarefaDTO)
    {
        var tarefa = await _tarefaRepository.BuscarPorId(tarefaDTO.Id);

        tarefa.Nome = tarefaDTO.Nome;
        tarefa.Descricao = tarefaDTO.Descricao;
        tarefa.Responsavel = tarefaDTO.Responsavel;
        tarefa.Status = tarefaDTO.Status;

        await _tarefaRepository.AtualizarAsync(tarefa);
    }

    public async Task<IEnumerable<TarefaRetornoDTO>> BuscarAsync(StatusTarefa status)
    {
        var tarefas = await _tarefaRepository.BuscarAsync(status);
        return _mapper.Map<IEnumerable<TarefaRetornoDTO>>(tarefas);
    }

    public async Task<TarefaRetornoDTO> BuscarPorId(int id)
    {
        var tarefa = await _tarefaRepository.BuscarPorId(id);
        return _mapper.Map<TarefaRetornoDTO>(tarefa);
    }

    public async Task ExcluirAsync(int id)
    {
        await _tarefaRepository.ExcluirAsync(id);
    }

    public async Task<TarefaRetornoDTO?> InserirAsync(TarefaCriacaoDTO tarefaDTO)
    {
        var tarefa = new Tarefa(tarefaDTO.Nome, tarefaDTO.Descricao, tarefaDTO.Responsavel);
        await _tarefaRepository.InserirAsync(tarefa);
        return await BuscarPorId(tarefa.Id);
    }
}
