using System.Data;
using Domain.Entity;
using Domain.Models;
using Domain.Utils;
using Infra.Context;

namespace Infra.Repositories;

public interface IUsuarioRepository
{
    Usuario GetUsuarioLogin(string email, string senha);
    IEnumerable<Usuario> GetFuncionarios();
    IEnumerable<Usuario> GetClientes();
    void InsertUsuario(Usuario usuario);
    void UpdateUsuario(Usuario usuario);
}

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DBContext _context;

    public UsuarioRepository(DBContext context)
    {
        _context = context;
    }

    public Usuario GetUsuarioLogin(string email, string senha)
    {
        var usuario = _context.Usuario.FirstOrDefault(x => x.Email == email);
        if (usuario is null || !CriptografiaUtil.CompararSenhas(senha, usuario.Senha))
        {
            throw new DataException("Usuário não encontrado com essas combinação de e-mail e senha.");
        }
        return usuario;
    }

    public IEnumerable<Usuario> GetFuncionarios()
    {
        var usuarios = _context.Usuario.Where(x => x.Tipo == UsuarioTipo.Funcionario).ToList();
        return usuarios;
    }

    public IEnumerable<Usuario> GetClientes()
    {
        var usuarios = _context.Usuario.Where(x => x.Tipo == UsuarioTipo.Cliente).ToList();
        return usuarios;
    }

    public void InsertUsuario(Usuario usuario)
    {
        var hasUsuario = _context.Usuario.Any(x =>
            x.Email == usuario.Email
            || x.CPF == usuario.CPF
            || x.Celular == usuario.Celular
        );

        if (hasUsuario)
            throw new Exception("Já existe um usuário com os dados informados");

        usuario.Senha = CriptografiaUtil.CriptografarSenha(usuario.Senha);
        _context.Usuario.Add(usuario);
        _context.SaveChanges();
    }

    public void UpdateUsuario(Usuario usuario)
    {
        var hasUsuario = _context.Usuario.Any(x =>
            (x.Email == usuario.Email || x.Celular == usuario.Celular) && x.Id != usuario.Id
        );

        if (hasUsuario)
            throw new Exception("Já existe um usuário com os dados informados");

        usuario.Senha = CriptografiaUtil.CriptografarSenha(usuario.Senha);
        _context.Usuario.Update(usuario);
        _context.SaveChanges();
    }
}