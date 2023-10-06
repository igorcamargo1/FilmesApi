namespace FilmesApi.Models;

/// <summary>
/// Modelo que representa um cinema.
/// </summary>
public class Cinema
{
    /// <summary>
    /// Obtém ou define o ID do cinema.
    /// </summary>
    [Key] // Indica que esta propriedade é a chave primária da tabela
    [Required] // Indica que o valor é obrigatório
    public int Id { get; set; }

    /// <summary>
    /// Obtém ou define o nome do cinema.
    /// </summary>
    [Required(ErrorMessage = "O campo de nome é obrigatório.")] // Define a mensagem de erro personalizada para quando o nome for nulo ou vazio
    public string Nome { get; set; }

    /// <summary>
    /// Obtém ou define o ID do endereço associado a este cinema.
    /// </summary>
    public int EnderecoId { get; set; }

    /// <summary>
    /// Obtém ou define o endereço associado a este cinema.
    /// </summary>
    public virtual Endereco Endereco { get; set; }

    /// <summary>
    /// Obtém ou define a coleção de sessões relacionadas a este cinema.
    /// </summary>
    public virtual ICollection<Sessao> Sessoes { get; set; }
}

