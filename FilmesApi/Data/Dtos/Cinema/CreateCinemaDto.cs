namespace FilmesApi.Data.Dtos.Cinema;

/// <summary>
/// Data Transfer Object (DTO) para criar um novo cinema.
/// </summary>
public class CreateCinemaDto
{
    /// <summary>
    /// Obtém ou define o nome do cinema.
    /// </summary>
    [Required(ErrorMessage = "O campo de nome é obrigatório.")] // Define a mensagem de erro personalizada para quando o nome for nulo ou vazio
    public string Nome { get; set; }

    /// <summary>
    /// Obtém ou define o ID do endereço associado ao cinema.
    /// </summary>
    public int EnderecoId { get; set; }
}

