using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pessoa> Pessoa { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>()
            .HasKey(p => p.PessoaId);
        modelBuilder.Entity<Pessoa>()
            .HasIndex(p => p.Cpf)
            .IsUnique();
        modelBuilder.Entity<Pessoa>()
            .Property(p => p.EstaAtivo)
            .HasMaxLength(1)
            .IsRequired();
    }
}