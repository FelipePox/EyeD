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


        /// <summary>
        /// Recupera todos os registros.
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        => Ok(await _hmdServices.GetAll());


        /// <summary>
        /// Recupera registro pelo ID.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
          => Ok(await _hmdServices.GetById(id));


        /// <summary>
        /// Registrar um novo HMD.
        /// </summary>
        /// 

        /// <remarks>
        /// Exemplo de payload:
        /// 
        ///     {
        ///        "sku": "MB-LCD-42-P",
        ///        "ipv4": "192.168.15.40",
        ///        "description": "Ocúlos região 3 - Sem riscos ou ocorrências",
        ///        "MacAddress": 00-1B-63-84-45-56,
        ///
        ///     }
        ///     
        /// </remarks>
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

        /// <summary>
        /// Editar HMD pelo seu ID.
        /// </summary>
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


        /// <summary>
        /// Deletar HMD pelo ID.
        /// </summary>
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
