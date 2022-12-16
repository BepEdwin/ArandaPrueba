using ArandaPrueba.Core.DTO;
using ArandaPrueba.Core.Entities;
using ArandaPrueba.Core.Interfaces;
using ArandaPrueba.Core.Request;

namespace ArandaPrueba.Core.Services
{
    public class TbProductosService : ITbProductosService
    {
        private readonly ITbProductosRepository _tbProductosRepository;

        public TbProductosService(ITbProductosRepository tbProductosRepository)
        {
            _tbProductosRepository = tbProductosRepository;
        }

        public async Task<(bool, IEnumerable<ProductosDTO>)> Get(string? nombre, string? descripcion, decimal? idCategoria)
        {
            var lstProductos = await _tbProductosRepository.Get();
            if (lstProductos.Item1)
            {
                if (nombre != null)
                    lstProductos.Item2 = lstProductos.Item2.Where(x => x.Nombre == nombre).ToList();
                if (descripcion != null)
                    lstProductos.Item2 = lstProductos.Item2.Where(x => x.DescripcionBreve.Contains(descripcion)).ToList();
                if (idCategoria != null)
                    lstProductos.Item2 = lstProductos.Item2.Where(x => x.IdCategoria == idCategoria).ToList();
            }

            return (lstProductos.Item1, lstProductos.Item2);
        }

        public Task<(bool, string)> Insert(ProductosRequest producto)
            => _tbProductosRepository.Insert(producto);

        public Task<(bool, string)> Update(TbProductos producto)
            => _tbProductosRepository.Update(producto);

        public Task<(bool, string)> Delete(decimal idProducto)
            => _tbProductosRepository.Delete(idProducto);

    }
}