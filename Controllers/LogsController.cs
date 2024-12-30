using AppVote01.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AppVote01.Data;
using AppVote01.Models;

namespace AppVote01.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class LogsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LogsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LogDto>> ListarLogs()
        {
            var logs = _context.Logs.ToList();
            return Ok(_mapper.Map<IEnumerable<LogDto>>(logs));
        }

        [HttpGet("{id}", Name = "ObterLogPorId")]
        public ActionResult<LogDto> ObterLogPorId(int id)
        {
            var log = _context.Logs.FirstOrDefault(l => l.Id == id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<LogDto>(log));
        }

        [HttpPost]
        public ActionResult<LogDto> CriarLog(LogCreateDto logDto)
        {
            var log = _mapper.Map<Log>(logDto);
            log.DataHora = DateTime.Now;
            _context.Logs.Add(log);
            _context.SaveChanges();
            return CreatedAtRoute(nameof(ObterLogPorId), new { id = log.Id }, _mapper.Map<LogDto>(log));
        }
    }
}