using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SunOnDemilich.Entities;

namespace SunOnDemilich.Context
{
    public partial class ContextoInicial : DbContext
    {
        public ContextoInicial()
        {
        }

        public ContextoInicial(DbContextOptions<ContextoInicial> options)
            : base(options)
        {
        }

        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; } = null!;
        public virtual DbSet<TbBbEp> TbBbEps { get; set; } = null!;
        public virtual DbSet<TbVgkg> TbVgkgs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=superidol;database=DB_DEMILICH", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.12-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<TbBbEp>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PRIMARY");

                entity.ToTable("TB_BB_EPS");

                entity.HasIndex(e => e.Cpf, "TB_BB_EPS_22_CPF_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.MatriculaFuncional, "TB_BB_EPS_22_MATRICULA_FUNCIONAL_uindex")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("CPF");

                entity.Property(e => e.Cmpt).HasColumnName("CMPT");

                entity.Property(e => e.CodComiss)
                    .HasColumnType("int(11)")
                    .HasColumnName("COD_COMISS");

                entity.Property(e => e.Comissao)
                    .HasMaxLength(64)
                    .HasColumnName("COMISSAO");

                entity.Property(e => e.Competencia)
                    .HasColumnType("int(11)")
                    .HasColumnName("COMPETENCIA");

                entity.Property(e => e.DataPosse).HasColumnName("DATA_POSSE");

                entity.Property(e => e.Dependencia)
                    .HasMaxLength(64)
                    .HasColumnName("DEPENDENCIA");

                entity.Property(e => e.Flag)
                    .HasMaxLength(32)
                    .HasColumnName("FLAG");

                entity.Property(e => e.Genero)
                    .HasColumnType("enum('Masculino','Feminino')")
                    .HasColumnName("GENERO");

                entity.Property(e => e.MatriculaFuncional)
                    .HasColumnType("int(11)")
                    .HasColumnName("MATRICULA_FUNCIONAL");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(64)
                    .HasColumnName("MUNICIPIO");

                entity.Property(e => e.Nascimento).HasColumnName("NASCIMENTO");

                entity.Property(e => e.Nome)
                    .HasMaxLength(64)
                    .HasColumnName("NOME");

                entity.Property(e => e.Prefixo)
                    .HasColumnType("int(11)")
                    .HasColumnName("PREFIXO");

                entity.Property(e => e.Uf)
                    .HasColumnType("enum('AC','AL','AM','AP','BA','CE','DF','ES','GO','MA','MG','MS','MT','PA','PB','PE','PI','PR','RJ','RN','RO','RR','RS','SC','SE','SP','TO')")
                    .HasColumnName("UF");
            });

            modelBuilder.Entity<TbVgkg>(entity =>
            {
                entity.ToTable("TB_VGKG");

                entity.HasIndex(e => e.Id, "TB_VGKG_ID_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Dttme)
                    .HasMaxLength(14)
                    .HasColumnName("DTTME")
                    .HasComment("Get the image's publication date and time.");

                entity.Property(e => e.Srce)
                    .HasMaxLength(1052)
                    .HasColumnName("SRCE")
                    .HasComment("Gets the source URI of the image.");

                entity.Property(e => e.Srcfd)
                    .HasMaxLength(255)
                    .HasColumnName("SRCFD")
                    .HasComment("Gets the source URI of the first article that used the image.");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
