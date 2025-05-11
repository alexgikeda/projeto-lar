using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PessoasController : ControllerBase
{
    private readonly IPessoaRepository _repository;

    public PessoasController(IPessoaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> ConsultarTodasPessoas() =>
        Ok(await _repository.ConsultarTodas());

    [HttpGet("{cpf}")]
    public async Task<IActionResult> ConsultarPessoasPorCpf(string cpf)
    {
        var pessoa = await _repository.ConsultarPorCpf(cpf);
        if (pessoa == null) return NotFound();
        return Ok(pessoa);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarPessoa([FromBody] Pessoa pessoa)
    {
        await _repository.Adicionar(pessoa);
        return CreatedAtAction(nameof(ConsultarPessoasPorCpf), new { cpf = pessoa.Cpf }, pessoa);
    }

    [HttpPut]
    public async Task<IActionResult> AlterarPessoa([FromBody] Pessoa pessoa)
    {
        await _repository.Alterar(pessoa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirPessoa(int id)
    {
        await _repository.Excluir(id);
        return NoContent();
    }
}