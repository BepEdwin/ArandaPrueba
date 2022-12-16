using ArandaPrueba.Core.DTO;
using ArandaPrueba.Core.Entities;
using ArandaPrueba.Core.Interfaces;
using ArandaPrueba.Core.Request;
using ArandaPrueba.Infraestructure.Helpers;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ArandaPrueba.Infraestructure.Repositories
{
    public class TbProductosRepository : ITbProductosRepository
    {
        private readonly ArandaDBContext _context;

        public TbProductosRepository(ArandaDBContext context)
        {
            _context = context;
        }

        public async Task<(bool, IEnumerable<ProductosDTO>)> Get()
        {
            try
            {
                var lstProductos = await (from a in _context.TbProducto
                                          join b in _context.TbCategoria
                                          on a.IdCategoria equals b.IdCategoria
                                          select new ProductosDTO
                                          {
                                              IdProducto = a.IdProducto,
                                              Nombre = a.Nombre,
                                              DescripcionBreve = a.DescripcionBreve,
                                              IdCategoria = b.IdCategoria,
                                              Categoria = b.Descripcion,
                                              ImagenProducto = a.ImagenProducto

                                          }).ToListAsync();

                if (lstProductos.Count > 0)
                    return (true, lstProductos);
                else
                    return (false, lstProductos);
            }
            catch
            {
                throw;
            }
        }

        public async Task<(bool, string)> Insert(ProductosRequest producto)
        {
            try
            {
                TbProductos record;
                if (producto.Imagen != null)
                {
                    byte[] imagen = Convert.FromBase64String(producto.Imagen);
                    record = new()
                    {
                        Nombre = producto.Nombre,
                        DescripcionBreve = producto.DescripcionBreve,
                        IdCategoria = producto.IdCategoria,
                        ImagenProducto = imagen
                    };
                }
                else
                {
                    record = new()
                    {
                        Nombre = producto.Nombre,
                        DescripcionBreve = producto.DescripcionBreve,
                        IdCategoria = producto.IdCategoria,
                        ImagenProducto = null
                    };
                }

                _context.TbProducto.Add(record);
                var regs = await _context.SaveChangesAsync();
                if (regs > 0)
                    return (true, Constantes.TbProductosConstantes.INSERT_SI);
                else
                    return (false, Constantes.TbProductosConstantes.INSERT_NO);
            }
            catch
            {
                throw;
            }
        }

        public async Task<(bool, string)> Update(TbProductos producto)
        {
            try
            {
                var record = await _context.TbProducto.SingleOrDefaultAsync(x => x.IdProducto == producto.IdProducto);
                if (record == null)
                    return (false, Constantes.TbProductosConstantes.NOT_FOUND);

                record.Nombre = producto.Nombre;
                record.DescripcionBreve = producto.DescripcionBreve;
                record.IdCategoria = producto.IdCategoria;
                record.ImagenProducto = producto.ImagenProducto;

                _context.TbProducto.Update(record);
                var regs = await _context.SaveChangesAsync();

                if (regs > 0)
                    return (true, Constantes.TbProductosConstantes.UPDATE_SI);
                else
                    return (false, Constantes.TbProductosConstantes.UPDATE_NO);
            }
            catch
            {
                throw;
            }
        }

        public async Task<(bool, string)> Delete(decimal idProducto)
        {
            try
            {
                var record = await _context.TbProducto.SingleOrDefaultAsync(x => x.IdProducto == idProducto);
                if (record == null)
                    return (false, Constantes.TbProductosConstantes.NOT_FOUND);

                _context.TbProducto.Remove(record);
                var regs = await _context.SaveChangesAsync();

                if (regs > 0)
                    return (true, Constantes.TbProductosConstantes.DELETE_SI);
                else
                    return (false, Constantes.TbProductosConstantes.DELETE_NO);
            }
            catch
            {
                throw;
            }
        }

    }
}
