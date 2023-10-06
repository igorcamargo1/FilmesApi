namespace FilmesApi.Profiles;

/// <summary>
/// Classe de perfil que define mapeamentos entre objetos DTO (Data Transfer Object) e objetos do modelo Cinema.
/// </summary>
public class CinemaProfile : Profile
{
    /// <summary>
    /// Inicializa uma nova instância da classe CinemaProfile.
    /// Define os mapeamentos entre os objetos DTO e os objetos do modelo Cinema.
    /// </summary>
    public CinemaProfile()
    {
        // Mapeia o objeto CreateCinemaDto para o modelo Cinema.
        CreateMap<CreateCinemaDto, Cinema>();

        // Mapeia o modelo Cinema para o objeto ReadCinemaDto.
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Endereco,
            opt => opt.MapFrom(cinema => cinema.Endereco))
            .ForMember(cinemaDto => cinemaDto.Sessoes,
            opt => opt.MapFrom(cinema => cinema.Sessoes));

        // Mapeia o objeto UpdateCinemaDto para o modelo Cinema.
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}

