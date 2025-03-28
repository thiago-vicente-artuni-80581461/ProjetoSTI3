using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSTI3.Models.ValueObjects
{
    public class ClienteVO
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Categoria { get; set; }
    }
}
