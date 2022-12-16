using ArandaPrueba.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaPrueba.Core.Interfaces
{
    public interface ITbCategoriaService
    {
        Task<(bool, IEnumerable<TbCategoria>)> Get(decimal? idCategoria, string? descripcion);
        Task<(bool, string)> Insert(string descripcion);
        Task<(bool, string)> Update(decimal idCategoria, string descripcion);
        Task<(bool, string)> Delete(decimal idCategoria);
    }
}