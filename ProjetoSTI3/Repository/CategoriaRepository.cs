using ProjetoSTI3.Data;
using ProjetoSTI3.Models;
using ProjetoSTI3.Repository.Interface;

namespace ProjetoSTI3.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly Context _context;

        public CategoriaRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categoria.ToList();
        }
    }
}
