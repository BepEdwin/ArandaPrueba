using ArandaPrueba.Core.Entities;

namespace ArandaPrueba.Core.Interfaces
{
    public interface ITbCategoriaRepository
    {
        Task<(bool, IEnumerable<TbCategoria>)> Get();
        Task<(bool, string)> Insert(string descripcion);
        Task<(bool, string)> Update(decimal idCategoria, string descripcion);
        Task<(bool, string)> Delete(decimal idCategoria);
    }
}