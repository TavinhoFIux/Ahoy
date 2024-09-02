namespace Domain.Entitys
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<NoticiaTag> NoticiaTags { get; set; } = new List<NoticiaTag>();

    }
}
