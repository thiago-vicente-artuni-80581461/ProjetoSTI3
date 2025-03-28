using ProjetoSTI3.Data;
using ProjetoSTI3.Models;
using ProjetoSTI3.Repository.Interface;

namespace ProjetoSTI3.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly Context _context;

        public ClienteRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Cliente.ToList();
        }
    }
}
