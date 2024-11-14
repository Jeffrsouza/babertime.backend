using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Infra.Context;
using System.Security.Cryptography.X509Certificates;

namespace Infra.Repositories;

public interface IServicoRepository
{
    IEnumerable<Servico> GetAll();
    void InsertServico(Servico servico);
    void DeleteServico(int id);
}

public class ServicoRepository : IServicoRepository
{
    private readonly DBContext _context;

    public ServicoRepository(DBContext context)
    {
        _context = context;
    }

    public IEnumerable<Servico> GetAll()
    {
        return _context.Servico.Where(x => !x.Deletado).OrderBy(x => x.Id);
    }

    public void InsertServico(Servico servico)
    {
        _context.Servico.Add(servico);
        _context.SaveChanges();
    }

    public void DeleteServico(int id)
    {
        var servico = _context.Servico.FirstOrDefault(s => s.Id == id);
        if (servico is not null)
        {
            servico.Deletado = true;
            _context.Servico.Update(servico);
            _context.SaveChanges();
        }
    }
}