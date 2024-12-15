using System.Data;
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
        try
        {

            var _agendamentos = _repository.GetAgendamentosByFuncionarioData(agendamento.Funcionario.Id, agendamento.Data);

            var inicioServico = NormalizaTempo(agendamento.Horas, agendamento.Minutos);
            var fimServico = NormalizaTempo(
                agendamento.Horas + agendamento.Servico.TempoHoras,
                agendamento.Minutos + agendamento.Servico.TempoMinutos
                );

            foreach (var x in _agendamentos)
            {
                var inicioAgendamento = NormalizaTempo(x.Horas, x.Minutos);
                var fimAgendamento = NormalizaTempo(x.Horas + x.Servico.TempoHoras, x.Minutos + x.Servico.TempoMinutos);

                if ((inicioServico >= inicioAgendamento && inicioServico <= fimAgendamento)
                    || (fimServico >= inicioAgendamento && fimServico <= fimAgendamento))
                {
                    throw new Exception("Já existe agendamento no horário solicitado.");
                }
            }
            _repository.InsertAgendamento(agendamento);
        }
        catch (Exception ex)
        {
            throw new Exception("Já existe agendamento no horário solicitado.");
        }
    }

    private int NormalizaTempo(int horas, int minutos)
    {
        var total = (horas * 60) + minutos;

        return total;
    }

    public void UpdateAgendamentoStatus(int agendamentoId, AgendamentoStatus statusId)
    {
        _repository.UpdateAgendamentoStatus(agendamentoId, statusId);
    }
}