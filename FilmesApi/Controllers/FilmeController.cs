namespace FilmesApi.Controllers;

/// <summary>
/// Controlador responsável por operações relacionadas a filmes.
/// </summary>
[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ListarFilmePorId), new { id = filme.Id }, filme);
    }

    /// <summary>
    /// Retorna uma lista de filmes com opção de paginação
    /// </summary>
    /// <param name="skip">Número de itens a serem pulados</param>
    /// <param name="take">Número máximo de itens a serem retornados</param>
    /// <param name="nomeCinema"></param>
    /// <returns>Uma coleção de objetos ReadFilmeDto</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadFilmeDto> ListarFilmes
        ([FromQuery] int skip = 0,
        [FromQuery] int take = 50,
        [FromQuery] string? nomeCinema = null)
    {
        if (nomeCinema == null)
        {
        return _mapper.Map<List<ReadFilmeDto>>
                (_context.Filmes.Skip(skip).Take(take).ToList());

        }
        return _mapper.Map<List<ReadFilmeDto>>
            (_context.Filmes.Skip(skip).Take(take)
            .Where(filme => filme.Sessoes
            .Any(sessao => sessao.Cinema.Nome == nomeCinema)).ToList());

    }

    /// <summary>
    /// Retorna informações sobre um filme com base no seu ID
    /// </summary>
    /// <param name="id">ID do filme a ser consultado</param>
    /// <returns>Um objeto ReadFilmeDto</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ListarFilmePorId( int id)
    {
        var filme =  _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);  
        return Ok(filme);
    }

    /// <summary>
    /// Atualiza informações de um filme com base no seu ID
    /// </summary>
    /// <param name="id">ID do filme a ser atualizado</param>
    /// <param name="filmeDto">Objeto com as informações atualizadas</param>
    /// <returns>Status 204 No Content se a atualização for bem-sucedida</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto) 
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Atualiza campos específicos de um filme com base no seu ID
    /// </summary>
    /// <param name="id">ID do filme a ser atualizado</param>
    /// <param name="patch">Objeto JsonPatchDocument contendo as atualizações</param>
    /// <returns>Status 204 No Content se a atualização for bem-sucedida</returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaCampoFilme(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Exclui um filme com base no seu ID
    /// </summary>
    /// <param name="id">ID do filme a ser excluído</param>
    /// <returns>Status 204 No Content se a exclusão for bem-sucedida</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}

