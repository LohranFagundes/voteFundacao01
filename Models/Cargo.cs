using System.ComponentModel.DataAnnotations;

namespace AppVote01.Models
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }
    }
}