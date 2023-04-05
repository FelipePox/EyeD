using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.HMDs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeD.WebApi.Controllers
{

    [ApiController]
    [Route("hmd")]
    public sealed class HMDController : ControllerBase
    {
        private readonly IHMDServices _hmdServices;
        public HMDController(IHMDServices hmdServices)
        {
            _hmdServices = hmdServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        => Ok(await _hmdServices.GetAll());

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
          => Ok(await _hmdServices.GetById(id));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] RequestHMDViewModel viewModel)
        {
            try
            {
                return Ok(await _hmdServices.Create(viewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] RequestHMDViewModel viewModel, Guid id)
        {
            try
            {
                return Ok(await _hmdServices.Edit(id, viewModel));
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
                if (await _hmdServices.Delete(id))
                    return Ok("HMD deletado com sucesso.");

                return BadRequest("Ocorreu um erro ao deletar o HMD.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
