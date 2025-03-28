using ProjetoSTI3.Models;
using ProjetoSTI3.Models.ValueObjects;

namespace ProjetoSTI3.Services.Interface
{
    public interface IPedidoService
    {
        void AlterarStatusPedido(Guid identificador);
        IEnumerable<FaturamentoVO> GetPedidos();
        void SalvarPedido(PedidoVO pedido, decimal desconto);
    }
}
