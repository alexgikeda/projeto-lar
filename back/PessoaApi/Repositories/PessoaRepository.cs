using Microsoft.EntityFrameworkCore;

public class PessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pessoa>> ConsultarTodas() => await _context.Pessoa.ToListAsync();

    public async Task<Pessoa?> ConsultarPorCpf(string cpf) =>
        await _context.Pessoa.FirstOrDefaultAsync(p => p.Cpf == cpf);

    public async Task Adicionar(Pessoa pessoa)
    {
        _context.Pessoa.Add(pessoa);
        await _context.SaveChangesAsync();
    }

    public async Task Alterar(Pessoa pessoa)
    {
        _context.Pessoa.Update(pessoa);
        await _context.SaveChangesAsync();
    }

    public async Task Excluir(int pessoaId)
    {
        var pessoa = await _context.Pessoa.FindAsync(pessoaId);
        if (pessoa != null)
        {
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}