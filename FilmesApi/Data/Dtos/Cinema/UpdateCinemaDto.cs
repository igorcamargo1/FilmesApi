namespace FilmesApi.Data.Dtos.Cinema;

/// <summary>
/// Data Transfer Object (DTO) para atualizar o nome de um cinema.
/// </summary>
public class UpdateCinemaDto
{
    /// <summary>
    /// Obtém ou define o novo nome do cinema.
    /// </summary>
    [Required(ErrorMessage = "O campo de nome é obrigatório.")] // Define a mensagem de erro personalizada para quando o nome for nulo ou vazio
    public string Nome { get; set; }
}
