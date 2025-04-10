using AdministradorTarefas.Domain.Entities;
using AdministradorTarefas.Domain.Interfaces;
using AdministradorTarefas.Infra.Data.Context;
using AdministradorTarefas.Util.Enums;
using Microsoft.EntityFrameworkCore;

namespace AdministradorTarefas.Infra.Data.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _context;

    public TarefaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tarefa>> BuscarAsync(StatusTarefa status)
    {
        if (status != StatusTarefa.Todos)
        {
            return await _context.Tarefas
                .AsNoTracking()
                .Where(c => c.Status == status)
                .ToListAsync();
        }

        return await _context.Tarefas
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Tarefa> BuscarPorId(int id)
    {
        var tarefa = await _context.Tarefas
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        return tarefa != null ? tarefa : throw new ArgumentException("Tarefa não encontrada");
    }

    public async Task InserirAsync(Tarefa tarefa)
    {
        await _context.Tarefas.AddAsync(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var tarefa = await BuscarPorId(id);

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
    }
}
