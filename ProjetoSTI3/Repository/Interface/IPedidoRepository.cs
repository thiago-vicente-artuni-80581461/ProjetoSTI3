using ProjetoSTI3.Models;
using ProjetoSTI3.Models.ValueObjects;

namespace ProjetoSTI3.Repository.Interface
{
    public interface IPedidoRepository
    {
        void AlterarStatusPedido(Guid identificador);
        IEnumerable<FaturamentoVO> GetPedidos();
        void SalvarPedido(PedidoVO pedido, decimal desconto);
    }
}
