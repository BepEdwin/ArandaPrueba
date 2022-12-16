using ArandaPrueba.Api.Helpers;
using ArandaPrueba.Api.Responses;
using ArandaPrueba.Core.Entities;
using ArandaPrueba.Core.Interfaces;
using ArandaPrueba.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ArandaPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ITbProductosService _productosService;

        public ProductosController(ITbProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet("GetProductos")]
        public async Task<IActionResult> Getproductos([FromQuery] string? nombre, string? descripcion, decimal? idCategoria)
        {
            try
            {
                var lstProductos = await _productosService.Get(nombre, descripcion, idCategoria);
                if (!lstProductos.Item1)
                    return Ok(new ResponseApi(lstProductos.Item1, Constantes.NOTFOUND, null, null));

                return Ok(new ResponseApi(lstProductos.Item1, Constantes.FOUND, null, lstProductos.Item2));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseApi(false, Constantes.ERROR_INTERNO, ex.Message, null));
            }
        }

        [HttpPost("InsertProducto")]
        public async Task<IActionResult> InsertProducto(ProductosRequest producto)
        {
            try
            {
                var response = await _productosService.Insert(producto);
                return Ok(new ResponseApi(response.Item1, response.Item2, null, null));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseApi(false, Constantes.ERROR_INTERNO, ex.Message, null));
            }
        }

        [HttpPut("UpdateProducto")]
        public async Task<IActionResult> UpdateProducto([FromBody] TbProductos producto)
        {
            try
            {
                var response = await _productosService.Update(producto);
                return Ok(new ResponseApi(response.Item1, response.Item2, null, null));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new ResponseApi(false, Constantes.ERROR_INTERNO, ex.Message, null));
            }
        }

        [HttpDelete("DeleteProducto")]
        public async Task<IActionResult> EliminarProducto([FromQuery] decimal idProducto)
        {
            try
            {
                var response = await _productosService.Delete(idProducto);
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