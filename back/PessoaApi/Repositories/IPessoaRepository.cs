public interface IPessoaRepository
{
    Task<List<Pessoa>> ConsultarTodas();
    Task<Pessoa?> ConsultarPorCpf(string cpf);
    Task Adicionar(Pessoa pessoa);
    Task Alterar(Pessoa pessoa);
    Task Excluir(int pessoaId);
}