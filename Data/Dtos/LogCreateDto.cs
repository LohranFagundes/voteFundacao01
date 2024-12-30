using System.ComponentModel.DataAnnotations;

namespace AppVote01.Dtos
{
    public class LogCreateDto
    {
        [Required]
        public string UsuarioId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Acao { get; set; }

        [MaxLength(255)]
        public string Ip { get; set; }
    }
}