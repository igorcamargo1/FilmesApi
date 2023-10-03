using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

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

    /// <summary>
    /// Obtém ou define um conjunto de entidades de Filme no banco de dados.
    /// </summary>
    public DbSet<Filme> Filmes { get; set; }
}
