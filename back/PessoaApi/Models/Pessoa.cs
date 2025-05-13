using System.ComponentModel.DataAnnotations.Schema;
using PessoaApi.Models;

public class Pessoa
{
    public int PessoaId { get; set; }
    public string Cpf { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string EstaAtivo { get; set; } = "S";

    public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
}