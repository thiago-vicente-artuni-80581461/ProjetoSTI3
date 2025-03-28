using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoSTI3.Models;
using ProjetoSTI3.Models.ValueObjects;
using ProjetoSTI3.Services.Interface;

namespace ProjetoSTI3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController
    {
        private readonly IClienteService _clienteService;
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IPedidoService _pedidoService;

        public PedidoController(IClienteService clienteService, IProdutoService produtoService, ICategoriaService categoriaService, IPedidoService pedidoService)
        {
            _clienteService = clienteService;
            _produtoService = produtoService;
            _categoriaService = categoriaService;
            _pedidoService = pedidoService;
        }

        [HttpPost(Name = "Pedido")]
        public PedidoVO Get([FromBody] PedidoVO pedido)
        {
            Cliente verificarCliente = new Cliente();
            Produto verificarProduto = new Produto();
            Categoria verificarCategoria = new Categoria();

            if (pedido.Cliente != null)
            {
                verificarCliente = _clienteService.GetClientes().FirstOrDefault(th => th.Id == pedido.Cliente.ClienteId);

                if (verificarCliente == null)
                {
                    return new PedidoVO();
                }

                verificarCategoria = _categoriaService.GetCategorias().FirstOrDefault(th => th.Nome == pedido.Cliente.Categoria);

                if (verificarCategoria == null)
                {
                    return new PedidoVO();
                }
            }

            foreach (var item in pedido.Itens)
            {
                verificarProduto = _produtoService.GetProdutos().FirstOrDefault(th => th.Id == item.ProdutoId && th.Nome == item.Descricao);

                if (verificarProduto == null)
                {
                    return new PedidoVO();
                }
            }
            
            _pedidoService.SalvarPedido(pedido, verificarCategoria.Desconto);

            return pedido;
        }
    }
}
