using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.Vehicles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeD.WebApi.Controllers;

[ApiController]
[Route("veiculo")]
public sealed class VehicleController : ControllerBase
{
    private readonly IVehicleServices _vehicleServices;

    public VehicleController(IVehicleServices vehicleServices)
    {
        _vehicleServices = vehicleServices;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
     => Ok(await _vehicleServices.GetAll());

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
       => Ok(await _vehicleServices.GetById(id));

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] RequestVehicleViewModel viewModel)
    {
        try
        {
            return Ok(await _vehicleServices.Create(viewModel));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize]
    public async Task<IActionResult> Put([FromBody] RequestVehicleViewModel viewModel, Guid id)
    {
        try
        {
            return Ok(await _vehicleServices.Edit(id, viewModel));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            if (await _vehicleServices.Delete(id))
                return Ok("Veículo deletado com sucesso.");

            return BadRequest("Ocorreu um erro ao deletar o Veículo.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
