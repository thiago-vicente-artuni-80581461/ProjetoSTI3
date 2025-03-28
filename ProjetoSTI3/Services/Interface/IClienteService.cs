using ProjetoSTI3.Models;

namespace ProjetoSTI3.Services.Interface
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetClientes();
    }
}
