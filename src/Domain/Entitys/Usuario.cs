namespace Domain.Entitys
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public ICollection<Noticia> Noticias { get; private set; } = new List<Noticia>();

        public Usuario(string nome, string email, string senha, int id)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            Id = id;
        }

    }
}
