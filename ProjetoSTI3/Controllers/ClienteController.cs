using Microsoft.AspNetCore.Mvc;
using ProjetoSTI3.Models;
using ProjetoSTI3.Services.Interface;

namespace ProjetoSTI3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet(Name = "Cliente")]
        public IEnumerable<Cliente> Get()
        {
            IEnumerable<Cliente> lista = _clienteService.GetClientes();
            return lista.ToArray();
        }
    }
}
