namespace ProjetoSTI3.Models.ValueObjects
{
    public class PedidoVO
    {
        public Guid Identificador { get; set; }
        public DateTime DataVenda { get; set; }

        public ClienteVO Cliente { get; set; }

        public IEnumerable<PedidoItemVO> Itens { get; set; }

    }
}
