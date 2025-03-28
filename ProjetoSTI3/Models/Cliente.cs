using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSTI3.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("Categoria")]
        public string Categoria { get; set; }
    }
}
