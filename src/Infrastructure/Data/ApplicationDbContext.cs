using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<NoticiaTag> NoticiaTags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoticiaTag>()
                .HasKey(nt => nt.Id);

            modelBuilder.Entity<NoticiaTag>()
                .HasOne(nt => nt.Noticia)
                .WithMany(n => n.NoticiaTags)
                .HasForeignKey(nt => nt.NoticiaId);

            modelBuilder.Entity<NoticiaTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NoticiaTags)
                .HasForeignKey(nt => nt.TagId);

            modelBuilder.Entity<Usuario>().HasData(new Usuario("Admin", "admin@example.com", "admin123"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
