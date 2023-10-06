namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Operações relacionadas a cinemas")]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo cinema.
        /// </summary>
        /// <param name="cinemaDto">Os dados do cinema a serem criados.</param>
        /// <returns>Os detalhes do cinema criado.</returns>
        [HttpPost]
        [SwaggerOperation("AdicionaCinema")]
        [SwaggerResponse(201, "Cinema criado com sucesso.", typeof(ReadCinemaDto))]
        [SwaggerResponse(400, "Requisição inválida.")]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = cinema.Id }, _mapper.Map<ReadCinemaDto>(cinema));
        }

        /// <summary>
        /// Obtém todos os cinemas ou os cinemas com base no ID do endereço.
        /// </summary>
        /// <param name="enderecoId">O ID do endereço para filtrar os cinemas (opcional).</param>
        /// <returns>Uma lista de cinemas.</returns>
        [HttpGet]
        [SwaggerOperation("RecuperaCinemas")]
        [SwaggerResponse(200, "Lista de cinemas obtida com sucesso.", typeof(IEnumerable<ReadCinemaDto>))]
        public IEnumerable<ReadCinemaDto> RecuperaCinemas([FromQuery] int? enderecoId = null)
        {
            if (enderecoId == null)
            {
                return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
            }

            var cinemasComEndereco = _context.Cinemas.FromSqlRaw($"SELECT Id, Nome, EnderecoId FROM cinemas WHERE cinemas.EnderecoId = {enderecoId} ").ToList();
            return _mapper.Map<List<ReadCinemaDto>>(cinemasComEndereco);
        }

        /// <summary>
        /// Obtém um cinema por ID.
        /// </summary>
        /// <param name="id">O ID do cinema a ser obtido.</param>
        /// <returns>Detalhes do cinema.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation("RecuperaCinemasPorId")]
        [SwaggerResponse(200, "Cinema encontrado.", typeof(ReadCinemaDto))]
        [SwaggerResponse(404, "Cinema não encontrado.")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        /// <summary>
        /// Atualiza um cinema por ID.
        /// </summary>
        /// <param name="id">O ID do cinema a ser atualizado.</param>
        /// <param name="cinemaDto">Os dados do cinema atualizado.</param>
        /// <returns>Status 204 No Content se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        [SwaggerOperation("AtualizaCinema")]
        [SwaggerResponse(204, "Cinema atualizado com sucesso.")]
        [SwaggerResponse(400, "Requisição inválida.")]
        [SwaggerResponse(404, "Cinema não encontrado.")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Exclui um cinema por ID.
        /// </summary>
        /// <param name="id">O ID do cinema a ser excluído.</param>
        /// <returns>Status 204 No Content se a exclusão for bem-sucedida.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation("DeletaCinema")]
        [SwaggerResponse(204, "Cinema excluído com sucesso.")]
        [SwaggerResponse(404, "Cinema não encontrado.")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
