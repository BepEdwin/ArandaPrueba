using ArandaPrueba.Core.DTO;
using ArandaPrueba.Core.Entities;
using ArandaPrueba.Core.Request;

namespace ArandaPrueba.Core.Interfaces
{
    public interface ITbProductosService
    {
        Task<(bool, IEnumerable<ProductosDTO>)> Get(string? nombre, string? descripcion, decimal? idCategoria);

        Task<(bool, string)> Insert(ProductosRequest producto);

        Task<(bool, string)> Update(TbProductos producto);

        Task<(bool, string)> Delete(decimal idProducto);
    }
}