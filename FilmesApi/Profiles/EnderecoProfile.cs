namespace FilmesApi.Profiles;

/// <summary>
/// Classe de perfil que define mapeamentos entre objetos DTO (Data Transfer Object) e objetos do modelo Endereco.
/// </summary>
public class EnderecoProfile : Profile
{
    /// <summary>
    /// Inicializa uma nova instância da classe EnderecoProfile.
    /// Define os mapeamentos entre os objetos DTO e os objetos do modelo Endereco.
    /// </summary>
    public EnderecoProfile()
    {
        // Mapeia o objeto CreateEnderecoDto para o modelo Endereco.
        CreateMap<CreateEnderecoDto, Endereco>();

        // Mapeia o modelo Endereco para o objeto ReadEnderecoDto.
        CreateMap<Endereco, ReadEnderecoDto>();

        // Mapeia o objeto UpdateEnderecoDto para o modelo Endereco.
        CreateMap<UpdateEnderecoDto, Endereco>();
    }
}

