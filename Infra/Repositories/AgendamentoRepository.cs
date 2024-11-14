using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Infra.Context;
using Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Repositories;

public interface IAgendamentoRepository
{
    IEnumerable<Agendamento> GetAll();
    IEnumerable<Agendamento> GetByCliente(int clienteId);
    void InsertAgendamento(Agendamento agendamento);
    void UpdateAgendamentoStatus(int agendamentoId, AgendamentoStatus statusId);

}

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly DBContext _context;

    public AgendamentoRepository(DBContext context)
    {
        _context = context;
    }
    public IEnumerable<Agendamento> GetAll()
    {
        var agendamentos = _context.Agendamento
            .Include(agendamento => agendamento.Servico)
            .Include(agendamento => agendamento.Cliente)
            .ToList();

        return agendamentos;
    }

    public IEnumerable<Agendamento> GetByCliente(int clienteId)
    {
        var agendamentos = _context.Agendamento
            .Include(agendamento => agendamento.Servico)
            .Include(agendamento => agendamento.Cliente)
            .Where(agendamento => 
                agendamento.Cliente == null ? false : agendamento.Cliente.Id == clienteId
                )
            .ToList();

        return agendamentos;
    }

    public void InsertAgendamento(Agendamento agendamento)
    {
        if(agendamento.Servico is not null)
            _context.Attach(agendamento.Servico);

        if(agendamento.Cliente is not null)
            _context.Attach(agendamento.Cliente);

        _context.Agendamento.Add(agendamento);
        _context.SaveChanges();
    }

    public void UpdateAgendamentoStatus(int agendamentoId, AgendamentoStatus statusId)
    {
        var agendamento = _context.Agendamento.FirstOrDefault(x => x.Id == agendamentoId);
        if (agendamento is not null)
        {
            agendamento.Status = statusId;
            _context.Agendamento.Update(agendamento);
            _context.SaveChanges();
        }
    }
}