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

    /// <summary>
    /// Recupera todos os registros.
    /// </summary>
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
     => Ok(await _vehicleServices.GetAll());

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
            return Ok(await _vehicleServices.GetById(id));
        }
        catch(Exception ex) 
        {
            return BadRequest(ex.Message);
        }
    }
      


    /// <summary>
    /// Registrar um novo Veículo.
    /// </summary>

    /// <remarks>
    /// Exemplo de payload:
    /// 
    ///     {
    ///        "plate": "BRA2E19",
    ///        "model": "Ford-Mustang 2018",
    ///        "modelYear": "2023",
    ///        "brand": "Ford",
    ///        "referenceDocument" : asd-fcd-fgcdsas,
    ///        "motivo" : "furto de carro"
    ///     }
    ///     
    /// </remarks>

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

    /// <summary>
    /// Editar Veículo pelo seu ID.
    /// </summary>
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

    /// <summary>
    /// Deletar Veículo pelo ID.
    /// </summary>
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
