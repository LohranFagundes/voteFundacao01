using AppVote01.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AppVote01.Data;
using AppVote01.Models;

namespace AppVote01.Controllers
    {
    [ApiController]
    [Route("api/cargos")]
    public class CargosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CargosController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CargoDto>> ListarCargos()
        {
            var cargos = _context.Cargos.ToList();
            return Ok(_mapper.Map<IEnumerable<CargoDto>>(cargos));
        }

        [HttpGet("{id}", Name = "ObterCargoPorId")]
        public ActionResult<CargoDto> ObterCargoPorId(int id)
        {
            var cargo = _context.Cargos.FirstOrDefault(c => c.Id == id);
            if (cargo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CargoDto>(cargo));
        }

        [HttpPost]
        public ActionResult<CargoDto> CriarCargo(CargoCreateDto cargoDto)
        {
            var cargo = _mapper.Map<Cargo>(cargoDto);
            _context.Cargos.Add(cargo);
            _context.SaveChanges();
            return CreatedAtRoute(nameof(ObterCargoPorId), new { id = cargo.Id }, _mapper.Map<CargoDto>(cargo));
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarCargo(int id, CargoUpdateDto cargoDto)
        {
            var cargo = _context.Cargos.FirstOrDefault(c => c.Id == id);
            if (cargo == null)
            {
                return NotFound();
            }
            _mapper.Map(cargoDto, cargo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarCargo(int id)
        {
            var cargo = _context.Cargos.FirstOrDefault(c => c.Id == id);
            if (cargo == null)
            {
                return NotFound();
            }
            _context.Cargos.Remove(cargo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
