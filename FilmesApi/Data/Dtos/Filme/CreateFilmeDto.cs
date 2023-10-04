namespace FilmesApi.Data.Dtos;

/// <summary>
/// DTO (Data Transfer Object) para criar um novo filme.
/// </summary>
public class CreateFilmeDto
{

    /// <summary>
    /// Obtém ou define o título do filme.
    /// </summary>
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string? Titulo { get; set; }

    /// <summary>
    /// Obtém ou define o gênero do filme.
    /// </summary>
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string? Genero { get; set; }

    /// <summary>
    /// Obtém ou define a duração do filme em minutos.
    /// </summary>
    [Required]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}
