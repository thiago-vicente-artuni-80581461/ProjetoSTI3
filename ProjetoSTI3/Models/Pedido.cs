using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSTI3.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("ClienteId")]
        public Guid ClienteId { get; set; }

        [Column("DataVenda")]
        public DateTime DataVenda { get; set; }

        [Column("SubTotal")]
        public decimal SubTotal { get; set; }

        [Column("Descontos")]
        public decimal Descontos { get; set; }

        [Column("ValorTotal")]
        public decimal ValorTotal { get; set; }

        [Column("Status")]
        public string Status { get; set; }
    }
}
