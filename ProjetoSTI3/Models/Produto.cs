using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSTI3.Models
{
    [Table("Produto")]
    public class Produto
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }
    }
}
