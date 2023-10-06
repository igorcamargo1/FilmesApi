namespace FilmesApi.Models;

/// <summary>
/// Modelo que representa uma sessão de cinema.
/// </summary>
public class Sessao
{
    /// <summary>
    /// Obtém ou define o ID do filme associado a esta sessão.
    /// </summary>
    public int? FilmeId { get; set; }

    /// <summary>
    /// Obtém ou define o filme associado a esta sessão.
    /// </summary>
    public virtual Filme Filme { get; set; }

    /// <summary>
    /// Obtém ou define o ID do cinema onde ocorre esta sessão.
    /// </summary>
    public int? CinemaId { get; set; }

    /// <summary>
    /// Obtém ou define o cinema associado a esta sessão.
    /// </summary>
    public virtual Cinema Cinema { get; set; }
}

