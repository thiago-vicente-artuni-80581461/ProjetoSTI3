using ProjetoSTI3.Data;
using ProjetoSTI3.Models;
using ProjetoSTI3.Repository.Interface;

namespace ProjetoSTI3.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly Context _context;

        public ProdutoRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Produto> GetProdutos()
        {
            return _context.Produto.ToList();
        }
    }
}
