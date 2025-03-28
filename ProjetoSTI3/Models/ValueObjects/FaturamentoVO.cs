namespace ProjetoSTI3.Models.ValueObjects
{
    public class FaturamentoVO
    {
        public Guid Identificador { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descontos { get; set; }
        public decimal ValorTotal { get; set; }

        public List<FaturamentoItemPedidoVO> Itens { get; set; } = new List<FaturamentoItemPedidoVO>();
    }
}
