namespace FilmesApi.Models;

/// <summary>
/// Modelo que representa um filme.
/// </summary>
public class Filme
{
    /// <summary>
    /// Obtém ou define o ID do filme.
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Obtém ou define o título do filme.
    /// </summary>
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string? Titulo { get; set; }

    /// <summary>
    /// Obtém ou define o gênero do filme.
    /// </summary>
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string? Genero { get; set; }

    /// <summary>
    /// Obtém ou define a duração do filme em minutos.
    /// </summary>
    [Required(ErrorMessage = "A duração é obrigatória")]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}
