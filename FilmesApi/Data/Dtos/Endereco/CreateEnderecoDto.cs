namespace FilmesApi.Data.Dtos.Endereco;

public class CreateEnderecoDto
{
    [Required(ErrorMessage = "O campo Logradouro precisa ser preenchido.")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo Numero precisa ser preenchido.")]
    public int Numero { get; set; }
}
