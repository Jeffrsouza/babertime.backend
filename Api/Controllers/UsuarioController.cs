using Service.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;

namespace Api;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("GetUsuarioLogin")]
    public IActionResult GetUsuarioLogin(string email, string senha)
    {
        try
        {
            return Ok(_service.GetUsuarioLogin(email, senha));
        }
        catch (Exception ex)
        {
            return BadRequest(new { StatusMessage = ex.Message, StatusCode = 400 });
        }
    }

    [HttpGet]
    [Route("GetFuncionarios")]
    public IActionResult GetFuncionarios()
    {
        try
        {
            return Ok(_service.GetFuncionarios());
        }
        catch (Exception ex)
        {
            return BadRequest(new { StatusMessage = ex.Message, StatusCode = 400 });
        }
    }

    [HttpGet]
    [Route("GetClientes")]
    public IActionResult GetClientes()
    {
        try
        {
            return Ok(_service.GetClientes());
        }
        catch (Exception ex)
        {
            return BadRequest(new { StatusMessage = ex.Message, StatusCode = 400 });
        }
    }

    [HttpPost]
    [Route("InsertUsuario")]
    public IActionResult InsertUsuario(Usuario usuario)
    {
        try
        {
            _service.InsertUsuario(usuario);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { StatusMessage = ex.Message, StatusCode = 400 });
        }
    }

    [HttpPut]
    [Route("UpdateUsuario")]
    public IActionResult UpdateUsuario(Usuario usuario)
    {
        try
        {
            _service.UpdateUsuario(usuario);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { StatusMessage = ex.Message, StatusCode = 400 });
        }
    }
}

