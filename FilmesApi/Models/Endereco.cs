namespace FilmesApi.Models;

/// <summary>
/// Modelo que representa um endereço.
/// </summary>
public class Endereco
{
    /// <summary>
    /// Obtém ou define o ID do endereço.
    /// </summary>
    [Key] // Indica que essa propriedade é a chave primária da tabela
    [Required] // Indica que o valor é obrigatório
    public int Id { get; set; }

    /// <summary>
    /// Obtém ou define o logradouro do endereço.
    /// </summary>
    [Required(ErrorMessage = "O campo Logradouro precisa ser preenchido.")] // Define a mensagem de erro personalizada para quando o logradouro for nulo ou vazio
    public string Logradouro { get; set; }

    /// <summary>
    /// Obtém ou define o número do endereço.
    /// </summary>
    [Required(ErrorMessage = "O campo Numero precisa ser preenchido.")] // Define a mensagem de erro personalizada para quando o número for zero
    public int Numero { get; set; }

    /// <summary>
    /// Obtém ou define o cinema associado a este endereço.
    /// </summary>
    public virtual Cinema Cinema { get; set; }
}

