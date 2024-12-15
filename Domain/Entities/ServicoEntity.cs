namespace Domain.Entity;

public class Servico
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public int TempoHoras { get; set; }
    public int TempoMinutos { get; set; }
    public bool Deletado { get; set; }
}