﻿namespace Domain.Entitys
{
    public class NoticiaTag
    {
        public int Id { get; set; }

        public int NoticiaId { get; set; }
        public Noticia Noticia { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
