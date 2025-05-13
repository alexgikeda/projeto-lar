namespace PessoaApi.DTOs
{
    public class PessoaDTO
    {
        public string Cpf { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string EstaAtivo { get; set; } = "S";

        public List<TelefoneDTO> Telefones { get; set; } = new();
    }
}
