namespace FilmesApi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage ="O campo Logradouro precisa ser preenchido.")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo Numero precisa ser preenchido.")]
    public int Numero { get; set; }

    public virtual Cinema Cinema { get; set; }
}
