using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HailOnDemilich.Entities;

namespace HailOnDemilich.Context
{
    public partial class DbPlntoEpsContext : DbContext
    {
        public DbPlntoEpsContext()
        {
        }

        public DbPlntoEpsContext(DbContextOptions<DbPlntoEpsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbClnca> TbClncas { get; set; } = null!;
        public virtual DbSet<TbClncaTpoAtdto> TbClncaTpoAtdtos { get; set; } = null!;
        public virtual DbSet<TbClncaTpoAtdtoLtcao> TbClncaTpoAtdtoLtcaos { get; set; } = null!;
        public virtual DbSet<TbCntto> TbCnttos { get; set; } = null!;
        public virtual DbSet<TbEmpsa> TbEmpsas { get; set; } = null!;
        public virtual DbSet<TbEmpsaCntto> TbEmpsaCnttos { get; set; } = null!;
        public virtual DbSet<TbExrco> TbExrcos { get; set; } = null!;
        public virtual DbSet<TbLogAtrzoBb> TbLogAtrzoBbs { get; set; } = null!;
        public virtual DbSet<TbLtcao> TbLtcaos { get; set; } = null!;
        public virtual DbSet<TbMncpo> TbMncpos { get; set; } = null!;
        public virtual DbSet<TbPrvso> TbPrvsos { get; set; } = null!;
        public virtual DbSet<TbPrvsoAtend> TbPrvsoAtends { get; set; } = null!;
        public virtual DbSet<TbPrvsoHstco> TbPrvsoHstcos { get; set; } = null!;
        public virtual DbSet<TbRegra> TbRegras { get; set; } = null!;
        public virtual DbSet<TbTpoAtdto> TbTpoAtdtos { get; set; } = null!;
        public virtual DbSet<TbTpoAtdtoEvntal> TbTpoAtdtoEvntals { get; set; } = null!;
        public virtual DbSet<TbUf> TbUfs { get; set; } = null!;
        public virtual DbSet<TbUor> TbUors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(
                    "data source=sqlserver.cassi.com.br;initial catalog=DB_PLNTO_EPS;user id=usreps;password=epsprd123$");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<TbClnca>(entity =>
            {
                entity.HasKey(e => e.IdClnca)
                    .HasName("PK_TB_PLNO")
                    .IsClustered(false);

                entity.ToTable("TB_CLNCA");

                entity.HasIndex(e => e.IdMncpo, "IDX_CLNCA_ID_MNCPO");

                entity.HasIndex(e => e.IdClnca, "IDX_CLNCA_ID_UF");

                entity.Property(e => e.IdClnca)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CLNCA");

                entity.Property(e => e.IdMncpo).HasColumnName("ID_MNCPO");

                entity.Property(e => e.IdUf).HasColumnName("ID_UF");

                entity.Property(e => e.InAtivo).HasColumnName("IN_ATIVO");

                entity.Property(e => e.NomClnca)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NOM_CLNCA");
            });

            modelBuilder.Entity<TbClncaTpoAtdto>(entity =>
            {
                entity.HasKey(e => e.IdClncaTpoAtdto)
                    .HasName("PK_CLNCA_TPO_ATDTO")
                    .IsClustered(false);

                entity.ToTable("TB_CLNCA_TPO_ATDTO");

                entity.HasIndex(e => e.IdClnca, "IDX_CTA_ID_CLNCA");

                entity.HasIndex(e => e.IdTpoAtdto, "IDX_CTA_ID_TPO_ATDTO");

                entity.Property(e => e.IdClncaTpoAtdto).HasColumnName("ID_CLNCA_TPO_ATDTO");

                entity.Property(e => e.IdClnca).HasColumnName("ID_CLNCA");

                entity.Property(e => e.IdTpoAtdto).HasColumnName("ID_TPO_ATDTO");
            });

            modelBuilder.Entity<TbClncaTpoAtdtoLtcao>(entity =>
            {
                entity.HasKey(e => e.IdClncaTpoAtdtoLtcao)
                    .HasName("PK_ID_CLNCA_TPO_ATDTO_LTCAO")
                    .IsClustered(false);

                entity.ToTable("TB_CLNCA_TPO_ATDTO_LTCAO");

                entity.HasIndex(e => e.IdClncaTpoAtdto, "IDX_ID_CLNCA_TPO_ATDTO");

                entity.HasIndex(e => e.IdLtcao, "IDX_ID_LOTCAO");

                entity.Property(e => e.IdClncaTpoAtdtoLtcao).HasColumnName("ID_CLNCA_TPO_ATDTO_LTCAO");

                entity.Property(e => e.IdClncaTpoAtdto).HasColumnName("ID_CLNCA_TPO_ATDTO");

                entity.Property(e => e.IdExrco).HasColumnName("ID_EXRCO");

                entity.Property(e => e.IdLtcao).HasColumnName("ID_LTCAO");
            });

            modelBuilder.Entity<TbCntto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_CNTTO");

                entity.Property(e => e.CdCntto).HasColumnName("CD_CNTTO");

                entity.Property(e => e.DsCntto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DS_CNTTO");

                entity.Property(e => e.IdCntto).HasColumnName("ID_CNTTO");

                entity.Property(e => e.InStcao).HasColumnName("IN_STCAO");
            });

            modelBuilder.Entity<TbEmpsa>(entity =>
            {
                entity.HasKey(e => e.IdEmpsa)
                    .HasName("PK_ID_EMPSA")
                    .IsClustered(false);

                entity.ToTable("TB_EMPSA");

                entity.Property(e => e.IdEmpsa).HasColumnName("ID_EMPSA");

                entity.Property(e => e.NmEmpsa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NM_EMPSA");
            });

            modelBuilder.Entity<TbEmpsaCntto>(entity =>
            {
                entity.HasKey(e => e.IdFrmroCntto)
                    .HasName("PK_FRMRO_CNTTO")
                    .IsClustered(false);

                entity.ToTable("TB_EMPSA_CNTTO");

                entity.Property(e => e.IdFrmroCntto).HasColumnName("ID_FRMRO_CNTTO");

                entity.Property(e => e.IdCntto).HasColumnName("ID_CNTTO");

                entity.Property(e => e.IdEmpsa).HasColumnName("ID_EMPSA");
            });

            modelBuilder.Entity<TbExrco>(entity =>
            {
                entity.HasKey(e => e.IdExrco)
                    .HasName("PK__TB_EXRCO__031B64BD30E3D83C");

                entity.ToTable("TB_EXRCO");

                entity.Property(e => e.IdExrco).HasColumnName("ID_EXRCO");

                entity.Property(e => e.CdAno).HasColumnName("CD_ANO");

                entity.Property(e => e.DsExrco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DS_EXRCO");

                entity.Property(e => e.DtVldco)
                    .HasColumnType("date")
                    .HasColumnName("DT_VLDCO");

                entity.Property(e => e.StExrco).HasColumnName("ST_EXRCO");
            });

            modelBuilder.Entity<TbLogAtrzoBb>(entity =>
            {
                entity.HasKey(e => e.IdAutorizacao)
                    .HasName("PK__TB_LOG_A__B233938B9BB2D77C");

                entity.ToTable("TB_LOG_ATRZO_BB");

                entity.Property(e => e.IdAutorizacao).HasColumnName("ID_AUTORIZACAO");

                entity.Property(e => e.CpfUsr)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF_USR");

                entity.Property(e => e.DsEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DS_EMAIL");

                entity.Property(e => e.DscLoginUsr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DSC_LOGIN_USR");

                entity.Property(e => e.DtInsercao)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_INSERCAO");

                entity.Property(e => e.NmUsr)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NM_USR");

                entity.Property(e => e.TpAtdto).HasColumnName("TP_ATDTO");
            });

            modelBuilder.Entity<TbLtcao>(entity =>
            {
                entity.HasKey(e => e.IdLtcao)
                    .HasName("PK_ID_LTCAO")
                    .IsClustered(false);

                entity.ToTable("TB_LTCAO");

                entity.Property(e => e.IdLtcao)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_LTCAO");

                entity.Property(e => e.CdLtcao).HasColumnName("CD_LTCAO");

                entity.Property(e => e.IdCntto).HasColumnName("ID_CNTTO");

                entity.Property(e => e.IdMncpo).HasColumnName("ID_MNCPO");

                entity.Property(e => e.IdUf).HasColumnName("ID_UF");

                entity.Property(e => e.InAdcno).HasColumnName("IN_ADCNO");

                entity.Property(e => e.NomLtcao)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NOM_LTCAO");

                entity.Property(e => e.NrCnpj)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NR_CNPJ");
            });

            modelBuilder.Entity<TbMncpo>(entity =>
            {
                entity.HasKey(e => e.IdMncpo)
                    .HasName("PK_ID_MNCPO")
                    .IsClustered(false);

                entity.ToTable("TB_MNCPO");

                entity.Property(e => e.IdMncpo)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_MNCPO");

                entity.Property(e => e.IdUf).HasColumnName("ID_UF");

                entity.Property(e => e.NmMncpo)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NM_MNCPO");
            });

            modelBuilder.Entity<TbPrvso>(entity =>
            {
                entity.HasKey(e => new { e.IdBnfco, e.IdExrco })
                    .HasName("PK_ID_BNFCO_ID_EXRCO");

                entity.ToTable("TB_PRVSO");

                entity.HasIndex(e => e.IdClncaTpoAtdto, "IDX_ID_CLNCA_TPO_ATDTO");

                entity.HasIndex(e => new { e.IdExrco, e.IdCntto }, "IDX_ID_EXRCO_CNTTO");

                entity.HasIndex(e => e.IdPrvsoAtend, "IDX_ID_PRVSO_ATEND");

                entity.HasIndex(e => e.IdLtcao, "IDX_PRVSO_ID_LTCAO");

                entity.HasIndex(e => e.IdMncpo, "IDX_PRVSO_ID_MNCPO");

                entity.HasIndex(e => e.IdUf, "IDX_PRVSO_ID_UF");

                entity.HasIndex(e => e.NomBnfco, "IDX_PRVSO_NOM_BNFCO");

                entity.HasIndex(e => e.NrCpf, "IDX_PRVSO_NR_CPF");

                entity.HasIndex(e => e.NrMatriculca, "IDX_PRVSO_NR_MATRICULCA");

                entity.Property(e => e.IdBnfco).HasColumnName("ID_BNFCO");

                entity.Property(e => e.IdExrco).HasColumnName("ID_EXRCO");

                entity.Property(e => e.CdLtcao).HasColumnName("CD_LTCAO");

                entity.Property(e => e.DsEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DS_EMAIL");

                entity.Property(e => e.DtAteto)
                    .HasColumnType("date")
                    .HasColumnName("DT_ATETO");

                entity.Property(e => e.DtInclusao)
                    .HasColumnType("date")
                    .HasColumnName("DT_INCLUSAO");

                entity.Property(e => e.DtNscto)
                    .HasColumnType("date")
                    .HasColumnName("DT_NSCTO");

                entity.Property(e => e.IdClncaTpoAtdto).HasColumnName("ID_CLNCA_TPO_ATDTO");

                entity.Property(e => e.IdCntto).HasColumnName("ID_CNTTO");

                entity.Property(e => e.IdCrgo).HasColumnName("ID_CRGO");

                entity.Property(e => e.IdLtcao).HasColumnName("ID_LTCAO");

                entity.Property(e => e.IdLtcaoPrvso).HasColumnName("ID_LTCAO_PRVSO");

                entity.Property(e => e.IdMncpo).HasColumnName("ID_MNCPO");

                entity.Property(e => e.IdPrvso)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_PRVSO");

                entity.Property(e => e.IdPrvsoAtend).HasColumnName("ID_PRVSO_ATEND");

                entity.Property(e => e.IdTpoAtdtoEvntal).HasColumnName("ID_TPO_ATDTO_EVNTAL");

                entity.Property(e => e.IdUf).HasColumnName("ID_UF");

                entity.Property(e => e.IdUfDstno).HasColumnName("ID_UF_DSTNO");

                entity.Property(e => e.IdUfPrvso).HasColumnName("ID_UF_PRVSO");

                entity.Property(e => e.IdUor).HasColumnName("ID_UOR");

                entity.Property(e => e.InAgndu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_AGNDU");

                entity.Property(e => e.InCndo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_CNDO")
                    .IsFixedLength();

                entity.Property(e => e.InFrmro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_FRMRO");

                entity.Property(e => e.InStcao)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("IN_STCAO");

                entity.Property(e => e.InTipoEps).HasColumnName("IN_TIPO_EPS");

                entity.Property(e => e.NomBnfco)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NOM_BNFCO");

                entity.Property(e => e.NrCpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("NR_CPF");

                entity.Property(e => e.NrMatriculca)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NR_MATRICULCA");

                entity.Property(e => e.TxMtvoClmto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_MTVO_CLMTO");

                entity.Property(e => e.TxObsao)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TX_OBSAO");
            });

            modelBuilder.Entity<TbPrvsoAtend>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_PRVSO_ATEND");

                entity.Property(e => e.DtPrvso)
                    .HasColumnType("date")
                    .HasColumnName("DT_PRVSO");

                entity.Property(e => e.IdClncaTpoAtdto).HasColumnName("ID_CLNCA_TPO_ATDTO");

                entity.Property(e => e.IdPrvsoAtend)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_PRVSO_ATEND");

                entity.Property(e => e.Medico)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("MEDICO");

                entity.Property(e => e.TxMsgem)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TX_MSGEM");
            });

            modelBuilder.Entity<TbPrvsoHstco>(entity =>
            {
                entity.HasKey(e => e.IdPrvsoHstco)
                    .HasName("PK_ID_PRVSO_HSTCO")
                    .IsClustered(false);

                entity.ToTable("TB_PRVSO_HSTCO");

                entity.Property(e => e.IdPrvsoHstco).HasColumnName("ID_PRVSO_HSTCO");

                entity.Property(e => e.DtInclusao)
                    .HasColumnType("date")
                    .HasColumnName("DT_INCLUSAO");

                entity.Property(e => e.IdBnfco).HasColumnName("ID_BNFCO");

                entity.Property(e => e.IdClncaTpoAtdto).HasColumnName("ID_CLNCA_TPO_ATDTO");

                entity.Property(e => e.IdLtcao).HasColumnName("ID_LTCAO");

                entity.Property(e => e.IdMncpo).HasColumnName("ID_MNCPO");

                entity.Property(e => e.IdPrvso).HasColumnName("ID_PRVSO");

                entity.Property(e => e.IdPrvsoAtend).HasColumnName("ID_PRVSO_ATEND");

                entity.Property(e => e.IdUf).HasColumnName("ID_UF");

                entity.Property(e => e.InStcao)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("IN_STCAO");

                entity.Property(e => e.TxMtvoClmto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_MTVO_CLMTO");
            });

            modelBuilder.Entity<TbRegra>(entity =>
            {
                entity.HasKey(e => e.IdRegra)
                    .HasName("PK__TB_REGRA__3F9C317886333B4A");

                entity.ToTable("TB_REGRA");

                entity.Property(e => e.IdRegra).HasColumnName("ID_REGRA");

                entity.Property(e => e.DsRegra)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DS_REGRA");

                entity.Property(e => e.DsTipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DS_TIPO");

                entity.Property(e => e.DtVldco)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_VLDCO");

                entity.Property(e => e.IdCntto).HasColumnName("ID_CNTTO");

                entity.Property(e => e.IdExrco).HasColumnName("ID_EXRCO");

                entity.Property(e => e.IdRegraSoc).HasColumnName("ID_REGRA_SOC");

                entity.Property(e => e.StRegra).HasColumnName("ST_REGRA");
            });

            modelBuilder.Entity<TbTpoAtdto>(entity =>
            {
                entity.HasKey(e => e.IdTpoAtdto)
                    .HasName("PK_ID_TPO_ATDTO")
                    .IsClustered(false);

                entity.ToTable("TB_TPO_ATDTO");

                entity.Property(e => e.IdTpoAtdto).HasColumnName("ID_TPO_ATDTO");

                entity.Property(e => e.CdTpoAgdto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CD_TPO_AGDTO");

                entity.Property(e => e.TxTpoAgdto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_TPO_AGDTO");
            });

            modelBuilder.Entity<TbTpoAtdtoEvntal>(entity =>
            {
                entity.HasKey(e => e.IdTpoAtdtoEvntal)
                    .HasName("PK_ID_TPO_ATDTO_EVNTAL")
                    .IsClustered(false);

                entity.ToTable("TB_TPO_ATDTO_EVNTAL");

                entity.Property(e => e.IdTpoAtdtoEvntal).HasColumnName("ID_TPO_ATDTO_EVNTAL");

                entity.Property(e => e.IdUf).HasColumnName("ID_UF");

                entity.Property(e => e.TxTpoAtdtoEvntal)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("TX_TPO_ATDTO_EVNTAL");
            });

            modelBuilder.Entity<TbUf>(entity =>
            {
                entity.HasKey(e => e.IdUf)
                    .HasName("PK_ID_UF")
                    .IsClustered(false);

                entity.ToTable("TB_UF");

                entity.Property(e => e.IdUf)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_UF");

                entity.Property(e => e.NmUf)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NM_UF");

                entity.Property(e => e.TxSgla)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TX_SGLA");
            });

            modelBuilder.Entity<TbUor>(entity =>
            {
                entity.ToTable("TB_UOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CdLtcao).HasColumnName("CD_LTCAO");

                entity.Property(e => e.CdUor).HasColumnName("CD_UOR");

                entity.Property(e => e.CdUorTrblo).HasColumnName("CD_UOR_TRBLO");

                entity.Property(e => e.IdMncpoTrblo).HasColumnName("ID_MNCPO_TRBLO");

                entity.Property(e => e.IdUfTrblo).HasColumnName("ID_UF_TRBLO");

                entity.Property(e => e.NmUorTrblo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NM_UOR_TRBLO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}