using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

/// <summary>
/// DTO (Data Transfer Object) para ler informações de um filme.
/// </summary>
public class ReadFilmeDto
{

    /// <summary>
    /// Obtém ou define o título do filme.
    /// </summary>
    public string? Titulo { get; set; }

    /// <summary>
    /// Obtém ou define o gênero do filme.
    /// </summary>
    public string? Genero { get; set; }

    /// <summary>
    /// Obtém ou define a duração do filme em minutos.
    /// </summary>
    public int Duracao { get; set; }

    /// <summary>
    /// Obtém ou define a hora da consulta. O valor padrão é a data e hora atuais.
    /// </summary>
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
