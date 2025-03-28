using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSTI3.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Categoria")]
        public string Nome { get; set; }

        [Column("Desconto")]
        public decimal Desconto { get; set; }

    }
}
