using ArandaPrueba.Core.Entities;
using ArandaPrueba.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using ArandaPrueba.Infraestructure.Helpers;

namespace ArandaPrueba.Infraestructure.Repositories
{
    public class TbCategoriaRepository : ITbCategoriaRepository
    {
        private readonly ArandaDBContext _context;

        public TbCategoriaRepository(ArandaDBContext context)
        {
            _context = context;
        }

        public async Task<(bool, IEnumerable<TbCategoria>)> Get()
        {
            try
            {
                var lstCategoria = await (from a in _context.TbCategoria
                                          select a).ToListAsync();

                if (lstCategoria.Count > 0)
                    return (true, lstCategoria);
                else
                    return (false, lstCategoria);
            }
            catch
            {
                throw;
            }
        }

        public async Task<(bool, string)> Insert(string descripcion)
        {
            try
            {
                var categoria = new TbCategoria() { Descripcion = descripcion };
                _context.TbCategoria.Add(categoria);

                var regs = await _context.SaveChangesAsync();
                if (regs > 0)
                    return (true, Constantes.TbCategoriaConstantes.INSERT_SI);
                else
                    return (true, Constantes.TbCategoriaConstantes.INSERT_NO);
            }
            catch
            {
                throw;
            }
        }

        public async Task<(bool, string)> Update(decimal idCategoria, string descripcion)
        {
            try
            {
                var record = await _context.TbCategoria.SingleOrDefaultAsync(x => x.IdCategoria == idCategoria);
                if (record == null)
                    return (false, Constantes.TbCategoriaConstantes.NOT_FOUND);

                record.Descripcion = descripcion;

                _context.TbCategoria.Update(record);
                var regs = await _context.SaveChangesAsync();

                if (regs > 0)
                    return (true, Constantes.TbCategoriaConstantes.UPDATE_SI);
                else
                    return (false, Constantes.TbCategoriaConstantes.UPDATE_NO);
            }
            catch
            {
                throw;
            }
        }

        public async Task<(bool, string)> Delete(decimal idCategoria)
        {
            try
            {
                var record = await _context.TbCategoria.SingleOrDefaultAsync(x => x.IdCategoria == idCategoria);
                if (record == null)
                    return (false, Constantes.TbCategoriaConstantes.NOT_FOUND);

                _context.TbCategoria.Remove(record);
                var regs = await _context.SaveChangesAsync();

                if (regs > 0)
                    return (true, Constantes.TbCategoriaConstantes.DELETE_SI);
                else
                    return (false, Constantes.TbCategoriaConstantes.DELETE_NO);
            }
            catch
            {
                throw;
            }
        }

    }
}