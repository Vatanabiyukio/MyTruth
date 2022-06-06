using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HailOnDemilich.Entities;

namespace HailOnDemilich.Context
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbBbCheckup> TbBbCheckups { get; set; } = null!;
        public virtual DbSet<TbBbEp> TbBbEps { get; set; } = null!;
        public virtual DbSet<TbCassi> TbCassis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;user=root;password=superidol;database=DB_DEMILICH",
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.12-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TbBbCheckup>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PRIMARY");

                entity.ToTable("TB_BB_CHECKUP");

                entity.HasIndex(e => e.Cpf, "TB_CHECKUP_CPF_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.MatriculaFuncional, "TB_CHECKUP_MATRICULA_FUNCIONAL_uindex")
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
                    .HasColumnType(
                        "enum('EX','AC','AL','AM','AP','BA','CE','DF','ES','GO','MA','MG','MS','MT','PA','PB','PE','PI','PR','RJ','RN','RO','RR','RS','SC','SE','SP','TO')")
                    .HasColumnName("UF");
            });

            modelBuilder.Entity<TbBbEp>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PRIMARY");

                entity.ToTable("TB_BB_EPS");

                entity.HasIndex(e => e.Cpf, "TB_CHECKUP_22_CPF_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.MatriculaFuncional, "TB_CHECKUP_22_MATRICULA_FUNCIONAL_uindex")
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
                    .HasColumnType(
                        "enum('EX','AC','AL','AM','AP','BA','CE','DF','ES','GO','MA','MG','MS','MT','PA','PB','PE','PI','PR','RJ','RN','RO','RR','RS','SC','SE','SP','TO')")
                    .HasColumnName("UF");
            });

            modelBuilder.Entity<TbCassi>(entity =>
            {
                entity.HasKey(e => e.NumCpf)
                    .HasName("PRIMARY");

                entity.ToTable("TB_CASSI");

                entity.HasIndex(e => e.Id, "TB_CASSI_Id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.NumCpf, "TB_CASSI_Num_cpf_uindex")
                    .IsUnique();

                entity.Property(e => e.NumCpf)
                    .HasMaxLength(11)
                    .HasColumnName("Num_cpf");

                entity.Property(e => e.AnoEps)
                    .HasColumnType("int(11)")
                    .HasColumnName("Ano_eps");

                entity.Property(e => e.AsoEntregue).HasColumnName("Aso_entregue");

                entity.Property(e => e.CentroCusto)
                    .HasMaxLength(8)
                    .HasColumnName("Centro_custo");

                entity.Property(e => e.DtAdmissao).HasColumnName("Dt_admissao");

                entity.Property(e => e.DtExame).HasColumnName("Dt_exame");

                entity.Property(e => e.DtNasc).HasColumnName("Dt_nasc");

                entity.Property(e => e.DtUltimoExame).HasColumnName("Dt_ultimo_exame");

                entity.Property(e => e.GerenciaExec)
                    .HasColumnType("int(11)")
                    .HasColumnName("Gerencia_exec");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Idade).HasColumnType("int(11)");

                entity.Property(e => e.LotSoc)
                    .HasColumnType("int(11)")
                    .HasColumnName("Lot_soc");

                entity.Property(e => e.MatSoc)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("Mat_soc");

                entity.Property(e => e.NomeCargo)
                    .HasMaxLength(64)
                    .HasColumnName("Nome_cargo");

                entity.Property(e => e.NomeEmpr)
                    .HasMaxLength(64)
                    .HasColumnName("Nome_empr");

                entity.Property(e => e.NumCargo)
                    .HasColumnType("int(11)")
                    .HasColumnName("Num_cargo");

                entity.Property(e => e.NumPess)
                    .HasColumnType("int(11)")
                    .HasColumnName("Num_pess");

                entity.Property(e => e.Periodicidade).HasColumnType("enum('Anual')");

                entity.Property(e => e.Sexo).HasColumnType("enum('Masculino','Feminino')");

                entity.Property(e => e.Situacao).HasColumnType("int(11)");

                entity.Property(e => e.Uf)
                    .HasColumnType(
                        "enum('EX','AC','AL','AM','AP','BA','CE','DF','ES','GO','MA','MG','MS','MT','PA','PB','PE','PI','PR','RJ','RN','RO','RR','RS','SC','SE','SP','TO')");

                entity.Property(e => e.UnidOrganizacional)
                    .HasMaxLength(64)
                    .HasColumnName("Unid_organizacional");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}