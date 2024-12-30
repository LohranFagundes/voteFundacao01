using System.ComponentModel.DataAnnotations;

namespace AppVote01.Dtos
{
    public class VotoCreateDto
    {
        [Required]
        public int CandidatoId { get; set; }
    }
}