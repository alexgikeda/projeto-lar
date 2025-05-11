using System.ComponentModel.DataAnnotations.Schema;

[Table("PESSOA")]
public class Pessoa
{
    [Column("PESSOAID")]
    public int PessoaId { get; set; }

    [Column("CPF")]
    public string Cpf { get; set; } = string.Empty;

    [Column("NOME")]
    public string Nome { get; set; } = string.Empty;

    [Column("DATANASCIMENTO")]
    public DateTime DataNascimento { get; set; }

    [Column("ESTAATIVO")]
    public string EstaAtivo { get; set; } = "S";
}