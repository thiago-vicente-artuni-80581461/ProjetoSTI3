using ProjetoSTI3.Models;
using ProjetoSTI3.Repository.Interface;
using ProjetoSTI3.Services.Interface;

namespace ProjetoSTI3.Services
{
    public class ClienteService : IClienteService
    {
        public readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _clienteRepository.GetClientes();
        }
    }
}
