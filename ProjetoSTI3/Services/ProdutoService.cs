using ProjetoSTI3.Models;
using ProjetoSTI3.Repository.Interface;
using ProjetoSTI3.Services.Interface;

namespace ProjetoSTI3.Services
{
    public class ProdutoService : IProdutoService
    {
        public readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> GetProdutos()
        {
            return _produtoRepository.GetProdutos();
        }
    }
}
