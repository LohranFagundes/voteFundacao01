using AppVote01.Data.Dtos;
using AppVote01.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppVote01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService
 emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("enviar")]

        public IActionResult EnviarEmail([FromBody] EmailDto emailDto)
        {
            try
            {
                _emailService.EnviarEmail(emailDto);
                return Ok("Email enviado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao enviar email: {ex.Message}");
            }
        }
    }
}