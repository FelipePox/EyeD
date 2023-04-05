﻿using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.User;
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


    [HttpPost]
    [Route("login")]
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
}