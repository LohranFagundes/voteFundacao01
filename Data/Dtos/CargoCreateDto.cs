using System.ComponentModel.DataAnnotations;

namespace AppVote01.Data.Dtos
{
    public class CargoCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }
    }
}
