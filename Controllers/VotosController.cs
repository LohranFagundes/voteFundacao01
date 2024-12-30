using AppVote01.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppVote01.Data;
using AppVote01.Models;

namespace AppVote01.Controllers
{
    [ApiController]
    [Route("api/votos")]
    public class VotosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VotosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VotoDto>> ListarVotos()
        {
            var votos = _context.Votos.ToList();
            return Ok(_mapper.Map<IEnumerable<VotoDto>>(votos));
        }

        [HttpGet("{id}", Name = "ObterVotoPorId")]
        public ActionResult<VotoDto> ObterVotoPorId(int id)
        {
            var voto = _context.Votos.FirstOrDefault(v => v.Id == id);
            if (voto == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VotoDto>(voto));
        }

        [Authorize]
        [HttpPost]
        public ActionResult<VotoDto> CriarVoto(VotoCreateDto votoDto)
        {
            var voto = _mapper.Map<Voto>(votoDto);

            // Obter o ID do usuário do token
            var userId = User.Identity.Name;

            // Obter o IP do usuário
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            voto.UsuarioId = userId;
            voto.DataHora = DateTime.Now;
            voto.Ip = ip;

            _context.Votos.Add(voto);
            _context.SaveChanges();
            return CreatedAtRoute(nameof(ObterVotoPorId), new { id = voto.Id }, _mapper.Map<VotoDto>(voto));
        }
    }
}