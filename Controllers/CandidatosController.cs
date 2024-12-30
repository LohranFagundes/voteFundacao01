using AppVote01.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AppVote01.Data;
using AppVote01.Models;

namespace AppVote01.Controllers
{
    [ApiController]
    [Route("api/candidatos")]
    public class CandidatosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CandidatosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CandidatoDto>> ListarCandidatos()
        {
            var candidatos = _context.Candidatos.ToList();
            return Ok(_mapper.Map<IEnumerable<CandidatoDto>>(candidatos));
        }

        [HttpGet("{id}", Name = "ObterCandidatoPorId")]
        public ActionResult<CandidatoDto> ObterCandidatoPorId(int id)
        {
            var candidato = _context.Candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CandidatoDto>(candidato));
        }

        [HttpPost]
        public ActionResult<CandidatoDto> CriarCandidato(CandidatoCreateDto candidatoDto)
        {
            var candidato = _mapper.Map<Candidato>(candidatoDto);
            _context.Candidatos.Add(candidato);
            _context.SaveChanges();
            return CreatedAtRoute(nameof(ObterCandidatoPorId), new { id = candidato.Id }, _mapper.Map<CandidatoDto>(candidato));
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarCandidato(int id, CandidatoUpdateDto candidatoDto)
        {
            var candidato = _context.Candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato == null)
            {
                return NotFound();
            }
            _mapper.Map(candidatoDto, candidato);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarCandidato(int id)
        {
            var candidato = _context.Candidatos.FirstOrDefault(c => c.Id == id);
            if (candidato == null)
            {
                return NotFound();
            }
            _context.Candidatos.Remove(candidato);
            _context.SaveChanges();
            return NoContent();
        }
    }
}