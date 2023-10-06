namespace FilmesApi.Data.Dtos.Endereco;

/// <summary>
/// Data Transfer Object (DTO) para criar um novo endereço.
/// </summary>
public class CreateEnderecoDto
{
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
}

