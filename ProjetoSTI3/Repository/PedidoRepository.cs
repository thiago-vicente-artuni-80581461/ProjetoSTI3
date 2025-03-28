using Microsoft.EntityFrameworkCore;
using ProjetoSTI3.Data;
using ProjetoSTI3.Models;
using ProjetoSTI3.Models.ValueObjects;
using ProjetoSTI3.Repository.Interface;

namespace ProjetoSTI3.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        public readonly Context _context;

        public PedidoRepository(Context context)
        {
            _context = context;
        }

        public void SalvarPedido(PedidoVO pedido, decimal desconto)
        {
            decimal descontos = 0;

            foreach (var item in pedido.Itens)
            {
                PedidoItem pedidoItem = new PedidoItem
                {
                    PedidoId = pedido.Identificador,
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario
                };

                _context.Add(pedidoItem);
                _context.SaveChanges();
            }

            var itemPedidoSoma = _context.PedidoItem.Where(th => th.PedidoId == pedido.Identificador).Sum(th => th.PrecoUnitario * th.Quantidade);

            var quantidade = _context.PedidoItem.Where(th => th.PedidoId == pedido.Identificador).Sum(th => th.Quantidade);

            if (itemPedidoSoma > 500 && pedido.Cliente.Categoria.Equals("REGULAR"))
            {
                descontos = (itemPedidoSoma * desconto) / 100;
            }
            else if (itemPedidoSoma > 300 && pedido.Cliente.Categoria.Equals("PREMIUM"))
            {
                descontos = (itemPedidoSoma * desconto) / 100;
            }
            else if (pedido.Cliente.Categoria.Equals("VIP"))
            {
                descontos = (itemPedidoSoma * desconto) / 100;
            }

            var total = itemPedidoSoma - descontos;

            Pedido pedidoNovo = new Pedido
            {
                Id = pedido.Identificador,
                ClienteId = pedido.Cliente.ClienteId,
                DataVenda = pedido.DataVenda,
                SubTotal = itemPedidoSoma,
                Descontos = descontos,
                ValorTotal = total,
                Status = "Pendente"
            };

            _context.Pedido.Add(pedidoNovo);
            _context.SaveChanges();
        }

        public IEnumerable<FaturamentoVO> GetPedidos()
        {
            List<FaturamentoVO> lista = new List<FaturamentoVO>();
            var result = _context.Pedido.Select(
                    (p) => new FaturamentoVO
                    {
                        Identificador = p.Id,
                        SubTotal = p.SubTotal,
                        Descontos = p.Descontos,
                        ValorTotal = p.ValorTotal
                    })
                .ToList();

            foreach (var item in result)
            {
                var itens = _context.PedidoItem.Where(th => th.PedidoId == item.Identificador).ToList();

                FaturamentoVO faturamento = new FaturamentoVO
                {
                    Identificador = item.Identificador,
                    SubTotal = item.SubTotal,
                    Descontos = item.Descontos,
                    ValorTotal = item.ValorTotal,
                };

                foreach (var i in itens)
                {
                    FaturamentoItemPedidoVO fatitem = new FaturamentoItemPedidoVO
                    {
                        Quantidade = i.Quantidade,
                        PrecoUnitario = i.PrecoUnitario
                    };
                    faturamento.Itens.Add(fatitem);     
                }
                lista.Add(faturamento);
            }
            return lista;
        }

        public void AlterarStatusPedido(Guid identificador)
        {
            var recuperarPedido = _context.Pedido.FirstOrDefault(th => th.Id == identificador);

            recuperarPedido.Status = "CONCLUÍDO";
            _context.Pedido.Update(recuperarPedido);
            _context.SaveChanges();
        }
    }
}
