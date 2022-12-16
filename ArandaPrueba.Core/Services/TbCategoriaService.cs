using ArandaPrueba.Core.Entities;
using ArandaPrueba.Core.Interfaces;

namespace ArandaPrueba.Core.Services
{
    public class TbCategoriaService : ITbCategoriaService
    {
        private readonly ITbCategoriaRepository _tbCategoriaRepository;

        public TbCategoriaService(ITbCategoriaRepository tbCategoriaRepository)
        {
            _tbCategoriaRepository = tbCategoriaRepository;
        }

        public async Task<(bool, IEnumerable<TbCategoria>)> Get(decimal? idCategoria, string? descripcion)
        {
            var records = await _tbCategoriaRepository.Get();
            if (records.Item1)
            {
                if (idCategoria != null)
                    records.Item2 = records.Item2.Where(x => x.IdCategoria == idCategoria).ToList();

                if (descripcion != null)
                    records.Item2 = records.Item2.Where(x => x.Descripcion == descripcion).ToList();
            }

            return (records.Item1, records.Item2);
        }

        public async Task<(bool, string)> Insert(string descripcion)
            => await _tbCategoriaRepository.Insert(descripcion);

        public async Task<(bool, string)> Update(decimal idCategoria, string descripcion)
            => await _tbCategoriaRepository.Update(idCategoria, descripcion);

        public async Task<(bool, string)> Delete(decimal idCategoria)
            => await _tbCategoriaRepository.Delete(idCategoria);

    }
}