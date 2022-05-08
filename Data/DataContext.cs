using AbaixoAsFakesApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbaixoAsFakesApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new NoticiaMap());
            modelBuilder.ApplyConfiguration(new VotoMap());
        }
    }

    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario)).HasKey(e => e.Id);
            builder.Property(x => x.Nome).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Senha).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(80).IsRequired();
            builder.Property(x => x.FormacaoAcademica).IsRequired();
            builder.Property(x => x.DataNascimento).IsRequired();
        }
    }

    public class NoticiaMap : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.ToTable(nameof(Noticia)).HasKey(e => e.Id);
            builder.Property(x => x.Fonte).HasMaxLength(100);
            builder.Property(x => x.Link).HasMaxLength(300);
            builder.Property(x => x.Titulo).HasMaxLength(80);
            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(fk => fk.IdUsuario);
        }
    }

    public class VotoMap : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {
            builder.ToTable(nameof(Voto)).HasKey(e => e.Id);
            builder.Property(x => x.TipoVoto);
            builder.HasOne(x => x.Noticia).WithMany().HasForeignKey(fk => fk.IdNoticia);
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(fk => fk.IdUsuario);
        }
    }
}
