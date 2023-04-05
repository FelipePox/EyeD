using EyeD.Application.Interfaces;
using EyeD.Application.ViewModels.Peoples;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeD.WebApi.Controllers
{
    [ApiController]
    [Route("pessoa")]
    public sealed class PeopleController : ControllerBase
    {
        private readonly IPeopleServices _peopleServices;

        public PeopleController(IPeopleServices peopleServices)
        {
            _peopleServices = peopleServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        => Ok(await _peopleServices.GetAll());


        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
         => Ok(await _peopleServices.GetById(id));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] RequestPeopleViewModel viewModel)
        {
            try
            {
                return Ok(await _peopleServices.Create(viewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] RequestPeopleViewModel viewModel, Guid id)
        {
            try
            {
                return Ok(await _peopleServices.Edit(id, viewModel));
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
                if (await _peopleServices.Delete(id))
                    return Ok("Pessoa deletado com sucesso.");

                return BadRequest("Ocorreu um erro ao deletar a Pessoa.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
