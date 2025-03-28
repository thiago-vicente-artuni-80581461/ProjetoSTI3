using ProjetoSTI3.Models;
using ProjetoSTI3.Repository.Interface;
using ProjetoSTI3.Services.Interface;

namespace ProjetoSTI3.Services
{
    public class CategoriaService : ICategoriaService
    {
        public readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _categoriaRepository.GetCategorias();
        }
    }
}
