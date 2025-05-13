using Microsoft.AspNetCore.Mvc;
using PessoaApi.DTOs;

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
    public async Task<IActionResult> AdicionarPessoa([FromBody] PessoaDTO pessoaDto)
    {
        await _repository.Adicionar(pessoaDto);
        return CreatedAtAction(nameof(ConsultarPessoasPorCpf), new { cpf = pessoaDto.Cpf }, pessoaDto);
    }

    [HttpPut("{cpf}")]
    public async Task<IActionResult> AlterarPessoa(string cpf,[FromBody] PessoaDTO pessoaDto)
    {
        await _repository.Alterar(cpf, pessoaDto);
        return NoContent();
    }

    [HttpDelete("{cpf}")]
    public async Task<IActionResult> ExcluirPessoa(string cpf)
    {
        await _repository.Excluir(cpf);
        return NoContent();
    }
}