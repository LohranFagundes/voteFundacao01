using System.ComponentModel.DataAnnotations;

namespace AppVote01.Dtos
{
    public class CandidatoCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        [Required]
        public int CargoId { get; set; }

        [Required]
        public string UsuarioId { get; set; }
    }
}