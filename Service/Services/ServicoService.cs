using Domain.Entity;
using Infra.Repositories;

namespace Service.Services;

public interface IServicoService
{
    IEnumerable<Servico> GetAll();
    void InsertServico(Servico servico);
    void DeleteServico(int id);
}

public class ServicoService : IServicoService
{
    private readonly IServicoRepository _repository;

    public ServicoService(IServicoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Servico> GetAll()
    {
        return _repository.GetAll();
    }

    public void InsertServico(Servico servico)
    {
        _repository.InsertServico(servico);
    }

    public void DeleteServico(int id)
    {
        _repository.DeleteServico(id);
    }
}