using Domain.Entity;
using Domain.Models;
using Infra.Repositories;

namespace Service.Services;

public interface IAgendamentoService
{
    IEnumerable<Agendamento> GetAll();
    IEnumerable<Agendamento> GetByCliente(int clienteId);
    void InsertAgendamento(Agendamento agendamento);
    void UpdateAgendamentoStatus(int agendamentoId, AgendamentoStatus statusId);
}

public class AgendamentoService : IAgendamentoService
{
    private readonly IAgendamentoRepository _repository;
    
    public AgendamentoService(IAgendamentoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Agendamento> GetAll()
    {
        var agendamentos = _repository.GetAll();
        return agendamentos;
    }

    public IEnumerable<Agendamento> GetByCliente(int clienteId)
    {
        var agendamentos = _repository.GetByCliente(clienteId);
        return agendamentos;
    }

    public void InsertAgendamento(Agendamento agendamento)
    {
        _repository.InsertAgendamento(agendamento);
    }

    public void UpdateAgendamentoStatus(int agendamentoId, AgendamentoStatus statusId)
    {
        _repository.UpdateAgendamentoStatus(agendamentoId, statusId);
    }
}