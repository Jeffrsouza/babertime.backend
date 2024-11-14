using Domain.Entity;
using Infra.Repositories;

namespace Service.Services;

public interface IUsuarioService
{
    Usuario GetUsuarioLogin(string email, string senha);
    IEnumerable<Usuario> GetFuncionarios();
    IEnumerable<Usuario> GetClientes();
    void InsertUsuario(Usuario usuario);
    void UpdateUsuario(Usuario usuario);
}

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public Usuario GetUsuarioLogin(string email, string senha)
    {
        return _repository.GetUsuarioLogin(email, senha);
    }

    public IEnumerable<Usuario> GetFuncionarios()
    {
        return _repository.GetFuncionarios();
    }

    public IEnumerable<Usuario> GetClientes()
    {
        return _repository.GetClientes();
    }

    public void InsertUsuario(Usuario usuario)
    {
        _repository.InsertUsuario(usuario);
    }

    public void UpdateUsuario(Usuario usuario)
    {
        _repository.UpdateUsuario(usuario);
    }
}