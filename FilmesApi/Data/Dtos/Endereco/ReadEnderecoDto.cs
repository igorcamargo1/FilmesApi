namespace FilmesApi.Data.Dtos.Endereco;

/// <summary>
/// Data Transfer Object (DTO) para representar as informações de um endereço em operações de leitura ou consulta.
/// </summary>
public class ReadEnderecoDto
{
    /// <summary>
    /// Obtém ou define o ID do endereço.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtém ou define o logradouro do endereço.
    /// </summary>
    public string Logradouro { get; set; }

    /// <summary>
    /// Obtém ou define o número do endereço.
    /// </summary>
    public int Numero { get; set; }
}

