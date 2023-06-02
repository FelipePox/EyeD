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

        /// <summary>
        /// Recupera todos os registros.
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        => Ok(await _peopleServices.GetAll());


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
                return Ok(await _peopleServices.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Recupera registro de pessoa pela FaceId.
        /// </summary>
        [HttpGet]
        [Route("faces/{faceId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByFaceId(string faceId)
        {
            try
            {
                return Ok(await _peopleServices.GetByFaceId(faceId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Registrar uma nova Pessoa.
        /// </summary>

        /// <remarks>
        /// Exemplo de payload:
        /// 
        ///     {
        ///        "firstName": "Felipe",
        ///        "faceId": 001B63844556,
        ///        "imageId": 001c6d844556,
        ///        "externalImageId": 001Bd63844d556,
        ///        "referenceDocument": document-23,   
        ///        "imagem" : url(https://imagem.com),
        ///        "motivo" : "Procurado por assasinato"
        ///     }
        /// </remarks>

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

        /// <summary>
        /// Editar Pessoa pelo seu ID.
        /// </summary>
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

        /// <summary>
        /// Deletar Pessoa pelo ID.
        /// </summary>
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
