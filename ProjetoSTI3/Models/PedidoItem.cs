using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSTI3.Models
{

    [Table("PedidoItem")]
    public class PedidoItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("PedidoId")]
        public Guid PedidoId { get; set; }

        [Column("ProdutoId")]
        public int ProdutoId { get; set; }

        [Column("Quantidade")]
        public decimal Quantidade { get; set; }

        [Column("PrecoUnitario")]
        public decimal PrecoUnitario { get; set; }
    }
}
