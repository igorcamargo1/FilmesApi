namespace FilmesApi.Profiles;

/// <summary>
/// Classe de perfil que define mapeamentos entre objetos DTO (Data Transfer Object) e objetos do modelo Sessao.
/// </summary>
public class SessaoProfile : Profile
{
    /// <summary>
    /// Inicializa uma nova instância da classe SessaoProfile.
    /// Define os mapeamentos entre os objetos DTO e os objetos do modelo Sessao.
    /// </summary>
    public SessaoProfile()
    {
        // Mapeia o objeto CreateSessaoDto para o modelo Sessao.
        CreateMap<CreateSessaoDto, Sessao>();

        // Mapeia o modelo Sessao para o objeto ReadSessaoDto.
        CreateMap<Sessao, ReadSessaoDto>();
    }
}

