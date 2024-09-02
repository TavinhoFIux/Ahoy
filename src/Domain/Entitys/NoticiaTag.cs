namespace Domain.Entitys
{
    public class NoticiaTag
    {
        public int Id { get; private set; }

        public int NoticiaId { get; private set; }
        public Noticia? Noticia { get; private set; }

        public int TagId { get; private set; }
        public Tag? Tag { get; private set; }


        public NoticiaTag(int noticiaId, int tagId)
        {
            NoticiaId = noticiaId;
            TagId = tagId;
        }
    }
}
