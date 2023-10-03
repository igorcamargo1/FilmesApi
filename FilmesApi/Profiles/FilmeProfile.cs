﻿using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

/// <summary>
/// Classe de perfil para mapear objetos entre DTOs e entidades de Filme.
/// </summary>
public class FilmeProfile : Profile
{
    /// <summary>
    /// Inicializa uma nova instância da classe FilmeProfile.
    /// </summary>
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();
    }
}
