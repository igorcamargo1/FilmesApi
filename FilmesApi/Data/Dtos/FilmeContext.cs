namespace FilmesApi.Data;

/// <summary>
/// Contexto de banco de dados para a entidade Filme.
/// </summary>
public class FilmeContext : DbContext
{
    /// <summary>
    /// Inicializa uma nova instância do contexto de banco de dados Filme.
    /// </summary>
    /// <param name="opts">Opções de configuração do contexto.</param>
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Sessao>()
            .HasKey(sessao => new {sessao.FilmeId,
            sessao.CinemaId});

        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);

        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.FilmeId);

        builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .OnDelete(DeleteBehavior.Restrict);
    }

    /// <summary>
    /// Obtém ou define um conjunto de entidades de Filme no banco de dados.
    /// </summary>
    public DbSet<Filme> Filmes { get; set; }

    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Endereco> Enderecos { get; set; }

    public DbSet<Sessao> Sessoes { get; set; }
}
