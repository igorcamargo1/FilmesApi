namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
[SwaggerTag("Operações relacionadas a endereços")]
public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Cria um novo endereço.
    /// </summary>
    /// <param name="enderecoDto">Os dados do endereço a serem criados.</param>
    /// <returns>Os detalhes do endereço criado.</returns>
    [HttpPost]
    [SwaggerOperation("AdicionaEndereco")]
    [SwaggerResponse(201, "Endereço criado com sucesso.", typeof(ReadEnderecoDto))]
    [SwaggerResponse(400, "Requisição inválida.")]
    public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, _mapper.Map<ReadEnderecoDto>(endereco));
    }

    /// <summary>
    /// Obtém todos os endereços.
    /// </summary>
    /// <returns>Uma lista de endereços.</returns>
    [HttpGet]
    [SwaggerOperation("RecuperaEnderecos")]
    [SwaggerResponse(200, "Lista de endereços obtida com sucesso.", typeof(IEnumerable<ReadEnderecoDto>))]
    public IEnumerable<ReadEnderecoDto> RecuperaEnderecos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);
    }

    /// <summary>
    /// Obtém um endereço por ID.
    /// </summary>
    /// <param name="id">O ID do endereço a ser obtido.</param>
    /// <returns>Detalhes do endereço.</returns>
    [HttpGet("{id}")]
    [SwaggerOperation("RecuperaEnderecosPorId")]
    [SwaggerResponse(200, "Endereço encontrado.", typeof(ReadEnderecoDto))]
    [SwaggerResponse(404, "Endereço não encontrado.")]
    public IActionResult RecuperaEnderecosPorId(int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(
            endereco => endereco.Id == id);
        if (endereco != null)
        {
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

            return Ok(enderecoDto);
        }
        return NotFound();
    }

    /// <summary>
    /// Atualiza um endereço por ID.
    /// </summary>
    /// <param name="id">O ID do endereço a ser atualizado.</param>
    /// <param name="enderecoDto">Os dados do endereço atualizado.</param>
    /// <returns>Status 204 No Content se a atualização for bem-sucedida.</returns>
    [HttpPut("{id}")]
    [SwaggerOperation("AtualizaEndereco")]
    [SwaggerResponse(204, "Endereço atualizado com sucesso.")]
    [SwaggerResponse(400, "Requisição inválida.")]
    [SwaggerResponse(404, "Endereço não encontrado.")]
    public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Exclui um endereço por ID.
    /// </summary>
    /// <param name="id">O ID do endereço a ser excluído.</param>
    /// <returns>Status 204 No Content se a exclusão for bem-sucedida.</returns>
    [HttpDelete("{id}")]
    [SwaggerOperation("DeletaEndereco")]
    [SwaggerResponse(204, "Endereço excluído com sucesso.")]
    [SwaggerResponse(404, "Endereço não encontrado.")]
    public IActionResult DeletaEndereco(int id)
    {
        Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null)
        {
            return NotFound();
        }
        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
}
