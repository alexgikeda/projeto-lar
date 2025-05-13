using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PessoaApi.DTOs;
using PessoaApi.Models;

public class PessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PessoaDTO>> ConsultarTodas()
    {
        var pessoaDTO = await _context.Pessoa.Include(p => p.Telefones)
                                             .Select(p => new PessoaDTO
                                             {
                                                Cpf = p.Cpf,
                                                Nome = p.Nome,
                                                DataNascimento = p.DataNascimento,
                                                EstaAtivo = p.EstaAtivo,
                                                Telefones = p.Telefones.Select(t => new TelefoneDTO
                                                {
                                                    Tipo = t.Tipo,
                                                    Numero = t.Numero
                                                }).ToList()
                                             })
                                             .ToListAsync();

        return pessoaDTO;
    }

    public async Task<PessoaDTO?> ConsultarPorCpf(string cpf)
    {
        var pessoaDTO = await _context.Pessoa.Include(p => p.Telefones)
                                             .Select(p => new PessoaDTO
                                             {
                                                Cpf = p.Cpf,
                                                Nome = p.Nome,
                                                DataNascimento = p.DataNascimento,
                                                EstaAtivo = p.EstaAtivo,
                                                Telefones = p.Telefones.Select(t => new TelefoneDTO
                                                {
                                                    Tipo = t.Tipo,
                                                    Numero = t.Numero
                                                }).ToList()
                                             })
                                             .FirstOrDefaultAsync(p => p.Cpf == cpf);

        return pessoaDTO;
    }

    public async Task Adicionar(PessoaDTO pessoaDto)
    {
        var pessoa = new Pessoa
        {
            Cpf = pessoaDto.Cpf,
            Nome = pessoaDto.Nome,
            DataNascimento = pessoaDto.DataNascimento,
            EstaAtivo = pessoaDto.EstaAtivo,
            Telefones = pessoaDto.Telefones.Select(t => new Telefone
            {
                Tipo = t.Tipo,
                Numero = t.Numero
            }).ToList()
        };

        _context.Pessoa.Add(pessoa);
        await _context.SaveChangesAsync();
    }

    public async Task Alterar(string cpf, PessoaDTO pessoaDto)
    {

        var pessoa = await _context.Pessoa.Include(p => p.Telefones)
                                          .FirstOrDefaultAsync(p => p.Cpf == cpf);

        if (pessoa == null) 
            throw new KeyNotFoundException($"Pessoa não encontrada."); ;

        pessoa.Nome = pessoaDto.Nome;
        pessoa.DataNascimento = pessoaDto.DataNascimento;
        pessoa.EstaAtivo = pessoaDto.EstaAtivo;

        // Telefones - apaga os antigos e adiciona os novos
        _context.Telefones.RemoveRange(pessoa.Telefones);
        pessoa.Telefones = pessoaDto.Telefones.Select(t => new Telefone
        {
            Tipo = t.Tipo,
            Numero = t.Numero,
            PessoaId = pessoa.PessoaId
        }).ToList();

        _context.Pessoa.Update(pessoa);
        await _context.SaveChangesAsync();
    }

    public async Task Excluir(string cpf)
    {
        var pessoa = await _context.Pessoa.Include(p => p.Telefones)
                                          .FirstOrDefaultAsync(p => p.Cpf == cpf);

        if (pessoa == null)
            throw new KeyNotFoundException($"Pessoa não encontrada."); ;

        _context.Telefones.RemoveRange(pessoa.Telefones);
        _context.Pessoa.Remove(pessoa);
        await _context.SaveChangesAsync();
    }
}