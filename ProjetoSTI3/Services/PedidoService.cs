using ProjetoSTI3.Models;
using ProjetoSTI3.Models.ValueObjects;
using ProjetoSTI3.Repository.Interface;
using ProjetoSTI3.Services.Interface;

namespace ProjetoSTI3.Services
{
    public class PedidoService : IPedidoService
    {
        public readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void SalvarPedido(PedidoVO pedido, decimal desconto)
        {
             _pedidoRepository.SalvarPedido(pedido, desconto);
        }

        public IEnumerable<FaturamentoVO> GetPedidos()
        {
           return _pedidoRepository.GetPedidos();
        }

        public void AlterarStatusPedido(Guid identificador)
        {
            _pedidoRepository.AlterarStatusPedido(identificador);
        }
    }
}
