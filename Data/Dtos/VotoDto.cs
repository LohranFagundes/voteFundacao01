namespace AppVote01.Dtos
{
    public class VotoDto
    {
        public int Id { get; set; }
        public int CandidatoId { get; set; }
        public string UsuarioId { get; set; }
        public DateTime DataHora { get; set; }
        public string Ip { get; set; }
    }
}