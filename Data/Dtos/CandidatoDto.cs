namespace AppVote01.Dtos
{
    public class CandidatoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargoId { get; set; }
        public string UsuarioId { get; set; }
    }
}