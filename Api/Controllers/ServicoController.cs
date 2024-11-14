using Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;

namespace Api;

[Route("api/[controller]")]
[ApiController]
public class ServicoController : ControllerBase
{
    private readonly IServicoService _service;

    public ServicoController(IServicoService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_service.GetAll());
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost]
    [Route("InsertServico")]
    public IActionResult InsertServico(Servico servico)
    {
        try
        {
            _service.InsertServico(servico);
            return Ok();
        }
        catch
        {
            return NoContent();
        }
    }
    
    [HttpDelete]
    [Route("DeleteServico")]
    public IActionResult DeleteServico(int id)
    {
        try
        {
            _service.DeleteServico(id);
            return Ok();
        }
        catch
        {
            return NoContent();
        }
    }
}
