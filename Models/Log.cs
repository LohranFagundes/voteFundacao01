using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppVote01.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UsuarioId { get; set; }
        public User Usuario { get; set; }

        public DateTime DataHora { get; set; }

        [Required]
        [MaxLength(255)]
        public string Acao { get; set; }

        [MaxLength(255)]
        public string Ip { get; set; }
    }
}