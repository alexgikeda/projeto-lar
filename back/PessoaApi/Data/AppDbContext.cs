using Microsoft.EntityFrameworkCore;
using PessoaApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Telefone> Telefones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.ToTable("PESSOA");
            entity.HasKey(p => p.PessoaId);
            entity.Property(p => p.PessoaId).HasColumnName("PESSOAID");
            entity.Property(p => p.Cpf).HasColumnName("CPF").IsRequired();
            entity.Property(p => p.Nome).HasColumnName("NOME").IsRequired();
            entity.Property(p => p.DataNascimento).HasColumnName("DATANASCIMENTO").IsRequired();
            entity.Property(p => p.EstaAtivo).HasColumnName("ESTAATIVO").IsRequired();
        });

        modelBuilder.Entity<Telefone>(entity =>
        {
            entity.ToTable("TELEFONE");
            entity.HasKey(t => t.TelefoneId);
            entity.Property(t => t.TelefoneId).HasColumnName("TELEFONEID");
            entity.Property(t => t.Tipo).HasColumnName("TIPO").IsRequired();
            entity.Property(t => t.Numero).HasColumnName("NUMERO").IsRequired();
            entity.Property(t => t.PessoaId).HasColumnName("PESSOAID").IsRequired();

            entity.HasOne(t => t.Pessoa)
                  .WithMany(p => p.Telefones)
                  .HasForeignKey(t => t.PessoaId);
        });
    }
}