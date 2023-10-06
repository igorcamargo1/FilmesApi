namespace FilmesApi.Data.Dtos.Sessao;

/// <summary>
/// Data Transfer Object (DTO) para criar uma nova sessão de cinema.
/// </summary>
public class CreateSessaoDto
{
    /// <summary>
    /// Obtém ou define o ID do filme associado a esta sessão.
    /// </summary>
    public int FilmeId { get; set; }

    /// <summary>
    /// Obtém ou define o ID do cinema onde ocorrerá esta sessão.
    /// </summary>
    public int CinemaId { get; set; }
}
