namespace Domain.Entity;

public class Servico
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string Tempo { get; set; } = string.Empty;
    public bool Deletado { get; set; }
}