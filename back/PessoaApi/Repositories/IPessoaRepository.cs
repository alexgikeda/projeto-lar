using PessoaApi.DTOs;

public interface IPessoaRepository
{
    Task<List<PessoaDTO>> ConsultarTodas();
    Task<PessoaDTO?> ConsultarPorCpf(string cpf);
    Task Adicionar(PessoaDTO pessoaDto);
    Task Alterar(string cpf, PessoaDTO pessoaDto);
    Task Excluir(string cpf);
}