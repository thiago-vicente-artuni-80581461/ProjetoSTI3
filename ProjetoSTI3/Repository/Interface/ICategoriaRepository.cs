using ProjetoSTI3.Models;

namespace ProjetoSTI3.Repository.Interface
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetCategorias();
    }
}
