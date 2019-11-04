using Microsoft.EntityFrameworkCore;
using Senai.LanHouse.Web.Razor.Models;

namespace Senai.LanHouse.Web.Razor.Contexts
{
    /// <summary>
    /// Contexto onde ficara o metodo de conexão com o banco de dados
    /// </summary>
    public partial class LanHouseContext : DbContext
    {
        public LanHouseContext()
        {
        }

        public LanHouseContext(DbContextOptions<LanHouseContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Equipamentos cadastrados
        /// </summary>
        public virtual DbSet<Equipamentos> Equipamentos { get; set; }
        /// <summary>
        /// Registros de defeitos dos equipamentos
        /// </summary>
        public virtual DbSet<RegistrosDefeitos> RegistrosDefeitos { get; set; }
        /// <summary>
        /// Tipos de defeitos
        /// </summary>
        public virtual DbSet<TiposDefeito> TiposDefeito { get; set; }
        /// <summary>
        /// Usuarios do sistema
        /// </summary>
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //"Data Source = .\SQLEXPRESS; initial catalog = LAN_HOUSE;user id = sa ; pwd = info@132" Microfsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Contexts -Context LanHouseContext
                optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; initial catalog = LAN_HOUSE;user id = sa ; pwd = info@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipamentos>(entity =>
            {
                entity.ToTable("EQUIPAMENTOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegistrosDefeitos>(entity =>
            {
                entity.ToTable("REGISTROS_DEFEITOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataDefeito)
                    .HasColumnName("DATA_DEFEITO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDefeito).HasColumnName("ID_DEFEITO");

                entity.Property(e => e.IdEquipamento).HasColumnName("ID_EQUIPAMENTO");

                entity.Property(e => e.Observacao)
                    .HasColumnName("OBSERVACAO")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdDefeitoNavigation)
                    .WithMany(p => p.RegistrosDefeitos)
                    .HasForeignKey(d => d.IdDefeito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROS__ID_DE__4E88ABD4");

                entity.HasOne(d => d.IdEquipamentoNavigation)
                    .WithMany(p => p.RegistrosDefeitos)
                    .HasForeignKey(d => d.IdEquipamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROS__ID_EQ__4D94879B");
            });

            modelBuilder.Entity<TiposDefeito>(entity =>
            {
                entity.ToTable("TIPOS_DEFEITO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
