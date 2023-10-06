namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
[SwaggerTag("Operações relacionadas a sessões de cinema")]
public class SessaoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Cria uma nova sessão de cinema.
    /// </summary>
    /// <param name="dto">Os dados da sessão a serem criados.</param>
    /// <returns>Os detalhes da sessão criada.</returns>
    [HttpPost]
    [SwaggerOperation("AdicionaSessao")]
    [SwaggerResponse(201, "Sessão criada com sucesso.")]
    public IActionResult AdicionaSessao([FromBody] CreateSessaoDto dto)
    {
        Sessao sessao = _mapper.Map<Sessao>(dto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaSessoesPorId), new
        { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, sessao);
    }

    /// <summary>
    /// Obtém todas as sessões de cinema.
    /// </summary>
    /// <returns>Uma lista de sessões de cinema.</returns>
    [HttpGet]
    [SwaggerOperation("RecuperaSessoes")]
    [SwaggerResponse(200, "Lista de sessões de cinema obtida com sucesso.", typeof(IEnumerable<ReadSessaoDto>))]
    public IEnumerable<ReadSessaoDto> RecuperaSessoes()
    {
        return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
    }

    /// <summary>
    /// Obtém uma sessão de cinema por ID de filme e ID de cinema.
    /// </summary>
    /// <param name="filmeId">O ID do filme.</param>
    /// <param name="cinemaId">O ID do cinema.</param>
    /// <returns>Detalhes da sessão de cinema.</returns>
    [HttpGet("{filmeId}/{cinemaId}")]
    [SwaggerOperation("RecuperaSessoesPorId")]
    [SwaggerResponse(200, "Sessão de cinema encontrada.", typeof(ReadSessaoDto))]
    [SwaggerResponse(404, "Sessão de cinema não encontrada.")]
    public IActionResult RecuperaSessoesPorId(int filmeId, int cinemaId)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(
            sessao => sessao.FilmeId == filmeId &&
            sessao.CinemaId == cinemaId);
        if (sessao != null)
        {
            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

            return Ok(sessaoDto);
        }
        return NotFound();
    }
}
