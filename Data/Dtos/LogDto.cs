namespace AppVote01.Dtos
{
    public class LogDto
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public DateTime DataHora { get; set; }
        public string Acao { get; set; }
        public string Ip { get; set; }
    }
}