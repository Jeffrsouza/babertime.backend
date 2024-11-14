using Domain.Entity;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api;

[Route("api/[controller]")]
[ApiController]
public class AgendamentoController : ControllerBase
{
    private readonly IAgendamentoService _service;

    public AgendamentoController(IAgendamentoService service)
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

    [HttpGet]
    [Route("GetByCliente")]
    public IActionResult GetByCliente(int clienteId)
    {
        try
        {
            return Ok(_service.GetByCliente(clienteId));
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost]
    [Route("InsertAgendamento")]
    public IActionResult InsertAgendamento(Agendamento agendamento)
    {
        try
        {
            _service.InsertAgendamento(agendamento);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { StatusMessage = ex.Message, StatusCode = 400 });
        }
    }    

    [HttpPut]
    [Route("UpdateAgendamentoStatus")]
    public IActionResult UpdateAgendamentoStatus(int agendamentoId, AgendamentoStatus statusId)
    {
        try
        {
            _service.UpdateAgendamentoStatus(agendamentoId, statusId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { StatusMessage = ex.Message, StatusCode = 400 });
        }
    }
}
