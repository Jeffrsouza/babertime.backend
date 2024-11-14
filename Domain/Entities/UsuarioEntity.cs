using Domain.Models;

namespace Domain.Entity;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Celular { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public UsuarioTipo Tipo { get; set; }
}