namespace FilmesApi.Data.Dtos.Cinema;

/// <summary>
/// Data Transfer Object (DTO) para representar as informações de um cinema em operações de leitura ou consulta.
/// </summary>
public class ReadCinemaDto
{
    /// <summary>
    /// Obtém ou define o ID do cinema.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtém ou define o nome do cinema.
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Obtém ou define as informações de endereço do cinema.
    /// </summary>
    public ReadEnderecoDto Endereco { get; set; }

    /// <summary>
    /// Obtém ou define uma coleção de informações de sessões relacionadas ao cinema.
    /// </summary>
    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}

