using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVote01.Models
{
    public class Voto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        [ForeignKey("User")]
        public string UsuarioId { get; set; }
        public User Usuario { get; set; }

        public DateTime DataHora { get; set; }

        [MaxLength(255)]
        public string Ip { get; set; }
    }
}