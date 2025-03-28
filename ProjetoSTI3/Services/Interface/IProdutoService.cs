using ProjetoSTI3.Models;

namespace ProjetoSTI3.Services.Interface
{
    public interface IProdutoService
    {
        IEnumerable<Produto> GetProdutos();
    }
}
