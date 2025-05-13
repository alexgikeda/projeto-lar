using System.ComponentModel.DataAnnotations.Schema;

namespace PessoaApi.Models
{
    public class Telefone
    {
        public int TelefoneId { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public int PessoaId { get; set; }

        public Pessoa? Pessoa { get; set; }
    }
}
