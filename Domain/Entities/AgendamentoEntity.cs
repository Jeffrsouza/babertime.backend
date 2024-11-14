using Domain.Models;

namespace Domain.Entity;

public class Agendamento
{
    public int Id { get; set; }
    public string Observacao { get; set; } = string.Empty;
    public AgendamentoStatus Status { get; set; }
    public DateTime Data { get; set; }
    public Servico? Servico { get; set; }
    public Usuario? Cliente { get; set; }
}