namespace FilmesApi.Data.Dtos.Sessao;

/// <summary>
/// Data Transfer Object (DTO) para representar uma sessão de cinema na leitura ou consulta.
/// </summary>
public class ReadSessaoDto
{
    /// <summary>
    /// Obtém ou define o ID do filme associado a esta sessão.
    /// </summary>
    public int FilmeId { get; set; }

    /// <summary>
    /// Obtém ou define o ID do cinema onde ocorre esta sessão.
    /// </summary>
    public int CinemaId { get; set; }
}

