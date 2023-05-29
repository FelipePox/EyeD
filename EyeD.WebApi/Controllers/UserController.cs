using EyeD.Application.Interfaces;
using EyeD.Application.Services;
using EyeD.Application.ViewModels.Peoples;
using EyeD.Application.ViewModels.User;
using EyeD.Application.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeD.WebApi.Controllers;

[ApiController]
[Route("users")]
[AllowAnonymous]
public sealed class UserController : ControllerBase
{
    private readonly IUserServices _userServices;

    public UserController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    /// <summary>
    /// Login de usuário para poder ter acesso completo das funcionalidades da API.
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestUserViewModel viewModel)
    {
        try
        {
            return Ok(await _userServices.Login(viewModel));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Recupera todos os registros.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    => Ok(await _userServices.GetAll());


    /// <summary>
    /// Recupera registro pelo ID.
    /// </summary>
    [HttpGet]
    [Route("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            return Ok(await _userServices.GetById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    /// <summary>
    /// Registrar um Novo usuário.
    /// </summary>

    /// <remarks>
    /// Exemplo de payload:
    /// 
    ///     {
    ///        "Nome": "Felipe",
    ///        "Senha": "Senha123.",
    ///        "email": "algumemail@gmail.com"
    ///  }   
    /// </remarks>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] RequestUserViewModel viewModel)
    {
        try
        {
            return Ok(await _userServices.Create(viewModel));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
