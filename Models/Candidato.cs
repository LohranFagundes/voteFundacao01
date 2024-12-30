using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVote01.Models
{
    public class Candidato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Descricao { get; set; }

        [ForeignKey("Cargo")]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        [ForeignKey("User")]
        public string UsuarioId { get; set; }
        public User Usuario { get; set; }
    }
}