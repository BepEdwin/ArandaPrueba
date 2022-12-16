using ArandaPrueba.Core.Interfaces;
using ArandaPrueba.Api.Responses;
using ArandaPrueba.Api.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ArandaPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ITbCategoriaService _categoriaService;

        public CategoriaController(ITbCategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("GetCategorias")]
        public async Task<IActionResult> GetCategorias([FromQuery] decimal? idCategoria, string? descripcion)
        {
            try
            {
                var lstCategoria = await _categoriaService.Get(idCategoria, descripcion);
                if (!lstCategoria.Item1)
                    return Ok(new ResponseApi(lstCategoria.Item1, Constantes.NOTFOUND, null, null));


                return Ok(new ResponseApi(lstCategoria.Item1, Constantes.FOUND, null, lstCategoria.Item2));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseApi(false, Constantes.ERROR_INTERNO, ex.Message, null));
            }
        }

        [HttpPost("InsertCategoria")]
        public async Task<IActionResult> InsertCategoria([FromQuery] string descripcion)
        {
            try
            {
                var response = await _categoriaService.Insert(descripcion);
                return Ok(new ResponseApi(response.Item1, response.Item2, null, null));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseApi(false, Constantes.ERROR_INTERNO, ex.Message, null));
            }
        }

        [HttpPut("UpdateCategoria")]
        public async Task<IActionResult> UpdateCategoria([FromQuery] decimal idCategoria, string descripcion)
        {
            try
            {
                var response = await _categoriaService.Update(idCategoria, descripcion);
                return Ok(new ResponseApi(response.Item1, response.Item2, null, null));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseApi(false, Constantes.ERROR_INTERNO, ex.Message, null));
            }
        }

        [HttpDelete("DeleteCategoria")]
        public async Task<IActionResult> DeleteCategoria([FromQuery] decimal idCategoria)
        {
            try
            {
                var response = await _categoriaService.Delete(idCategoria);
                return Ok(new ResponseApi(response.Item1, response.Item2, null, null));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseApi(false, Constantes.ERROR_INTERNO, ex.Message, null));
            }
        }

    }
}