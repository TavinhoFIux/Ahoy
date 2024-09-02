namespace Domain.Entitys
{
    public class Noticia
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string Texto { get; private set; } = string.Empty;
        public int UsuarioId { get; private set; }
        public Usuario? Usuario { get; private set; }
        public IEnumerable<NoticiaTag> NoticiaTags { get; private set; } = new List<NoticiaTag>();


        public Noticia(string titulo, string texto, int usuarioId)
        {
            Titulo = titulo;
            Texto = texto;
            UsuarioId = usuarioId;
        }

        public void Update(string titulo, string texto)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new ArgumentException("O título não pode ser vazio ou nulo.", nameof(titulo));
            }

            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new ArgumentException("O texto não pode ser vazio ou nulo.", nameof(texto));
            }

            Titulo = titulo;
            Texto = texto;
        }
    }
}
