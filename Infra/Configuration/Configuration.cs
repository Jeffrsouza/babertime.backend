using Domain.Entity;
using Domain.Models;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuration;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.HasData
        (
            new Usuario
            {
                Id = 1,
                Nome = "Admin",
                Celular = "",
                Email = "Admin",
                CPF = "",
                Senha = CriptografiaUtil.CriptografarSenha("Admin123"),
                Tipo = UsuarioTipo.Funcionario,
            }
        );
    }
}