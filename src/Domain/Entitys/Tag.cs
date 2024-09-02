namespace Domain.Entitys
{
    public class Tag
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; } = string.Empty;
        public ICollection<NoticiaTag> NoticiaTags { get; private set; } = new List<NoticiaTag>();

        public Tag(string descricao)
        {
            Descricao = descricao;
        }

        public void Update(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descricao não pode ser vazio ou nulo.", nameof(descricao));
            }

            Descricao = descricao;
        }
    }
}
