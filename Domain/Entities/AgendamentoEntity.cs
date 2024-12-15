using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace Domain.Entity;

public class Agendamento
{
    public int Id { get; set; }
    public string Observacao { get; set; } = string.Empty;
    public AgendamentoStatus Status { get; set; }

    [Column(TypeName = "Date")]
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }
    public int Horas { get; set; }
    public int Minutos { get; set; }
    public Servico? Servico { get; set; }
    public Usuario? Cliente { get; set; }
    public Usuario? Funcionario { get; set; }
}