using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HailOnDemilich.Entities;

namespace HailOnDemilich.Context
{
    public partial class DbFormContext : DbContext
    {
        public DbFormContext()
        {
        }

        public DbFormContext(DbContextOptions<DbFormContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbArqvo> TbArqvos { get; set; } = null!;
        public virtual DbSet<TbAso> TbAsos { get; set; } = null!;
        public virtual DbSet<TbCampo> TbCampos { get; set; } = null!;
        public virtual DbSet<TbCampoOld> TbCampoOlds { get; set; } = null!;
        public virtual DbSet<TbClna> TbClnas { get; set; } = null!;
        public virtual DbSet<TbClnasOld> TbClnasOlds { get; set; } = null!;
        public virtual DbSet<TbDpdca> TbDpdcas { get; set; } = null!;
        public virtual DbSet<TbDpdcaFrmro> TbDpdcaFrmros { get; set; } = null!;
        public virtual DbSet<TbEnvioMntto> TbEnvioMnttos { get; set; } = null!;
        public virtual DbSet<TbEnvioMnttoAso> TbEnvioMnttoAsos { get; set; } = null!;
        public virtual DbSet<TbEnvioMnttoAsoExame> TbEnvioMnttoAsoExames { get; set; } = null!;
        public virtual DbSet<TbEnvioMnttoHstcoStcao> TbEnvioMnttoHstcoStcaos { get; set; } = null!;
        public virtual DbSet<TbExptaFrmro> TbExptaFrmros { get; set; } = null!;
        public virtual DbSet<TbFrmro> TbFrmros { get; set; } = null!;
        public virtual DbSet<TbFrmroLog> TbFrmroLogs { get; set; } = null!;
        public virtual DbSet<TbFrmroOld> TbFrmroOlds { get; set; } = null!;
        public virtual DbSet<TbLogPrmtoFrmlo> TbLogPrmtoFrmlos { get; set; } = null!;
        public virtual DbSet<TbMdico> TbMdicos { get; set; } = null!;
        public virtual DbSet<TbOpcao> TbOpcaos { get; set; } = null!;
        public virtual DbSet<TbOpcaoOld> TbOpcaoOlds { get; set; } = null!;
        public virtual DbSet<TbOrdem> TbOrdems { get; set; } = null!;
        public virtual DbSet<TbPrcdoDgnso> TbPrcdoDgnsos { get; set; } = null!;
        public virtual DbSet<TbPrcdoDgnsoEscl> TbPrcdoDgnsoEscls { get; set; } = null!;
        public virtual DbSet<TbPrctoDgncoEscal> TbPrctoDgncoEscals { get; set; } = null!;
        public virtual DbSet<TbPrmtoFrmloPrcdoDgnso> TbPrmtoFrmloPrcdoDgnsos { get; set; } = null!;
        public virtual DbSet<TbRsptaCampo> TbRsptaCampos { get; set; } = null!;
        public virtual DbSet<TbRsptaFrmro> TbRsptaFrmros { get; set; } = null!;
        public virtual DbSet<TbRsptaFrmroMdico> TbRsptaFrmroMdicos { get; set; } = null!;
        public virtual DbSet<TbRsptaLog> TbRsptaLogs { get; set; } = null!;
        public virtual DbSet<TbRsptaOpcao> TbRsptaOpcaos { get; set; } = null!;
        public virtual DbSet<TbSssao> TbSssaos { get; set; } = null!;
        public virtual DbSet<TbSssaoOld> TbSssaoOlds { get; set; } = null!;
        public virtual DbSet<TbStcaoEnvioMntto> TbStcaoEnvioMnttos { get; set; } = null!;
        public virtual DbSet<TbStcoFrmro> TbStcoFrmros { get; set; } = null!;
        public virtual DbSet<TbStcoTrnsa> TbStcoTrnsas { get; set; } = null!;
        public virtual DbSet<TbTestefila> TbTestefilas { get; set; } = null!;
        public virtual DbSet<TbTipPrncoUsro> TbTipPrncoUsros { get; set; } = null!;
        public virtual DbSet<TbTipRfrnaVnclo> TbTipRfrnaVnclos { get; set; } = null!;
        public virtual DbSet<TbTipSssao> TbTipSssaos { get; set; } = null!;
        public virtual DbSet<TbTipoExameOcpal> TbTipoExameOcpals { get; set; } = null!;
        public virtual DbSet<TbTipoIndorCampoMntto> TbTipoIndorCampoMnttos { get; set; } = null!;
        public virtual DbSet<TbTipoMdico> TbTipoMdicos { get; set; } = null!;
        public virtual DbSet<TbTipoRstdoAso> TbTipoRstdoAsos { get; set; } = null!;
        public virtual DbSet<TbTipoRstdoExame> TbTipoRstdoExames { get; set; } = null!;
        public virtual DbSet<TbTpoRsptum> TbTpoRspta { get; set; } = null!;
        public virtual DbSet<TbTrmo> TbTrmos { get; set; } = null!;
        public virtual DbSet<TbTrnsa> TbTrnsas { get; set; } = null!;
        public virtual DbSet<TmpMedicoaso> TmpMedicoasos { get; set; } = null!;
        public virtual DbSet<TpSxo> TpSxos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(
                    "data source=sqlserver.cassi.com.br;initial catalog=DB_FORM;user id=usrform;password=formprd123$");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<TbArqvo>(entity =>
            {
                entity.HasKey(e => e.IdArqvo)
                    .HasName("PK__TB_ARQVO__D6F68C3A1BFFA36B");

                entity.ToTable("TB_ARQVO");

                entity.Property(e => e.IdArqvo).HasColumnName("ID_ARQVO");

                entity.Property(e => e.DscLclArqvo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DSC_LCL_ARQVO");

                entity.Property(e => e.DtImptoArqvo)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_IMPTO_ARQVO");

                entity.Property(e => e.IdBnfco).HasColumnName("ID_BNFCO");

                entity.Property(e => e.IdFmro).HasColumnName("ID_FMRO");

                entity.Property(e => e.IdRsptaFrmroAso).HasColumnName("ID_RSPTA_FRMRO_ASO");

                entity.Property(e => e.InCfrdo).HasColumnName("IN_CFRDO");

                entity.Property(e => e.NomArqvo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOM_ARQVO");

                entity.Property(e => e.QtdBtes).HasColumnName("QTD_BTES");

                entity.Property(e => e.TpArqvo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TP_ARQVO");
            });

            modelBuilder.Entity<TbAso>(entity =>
            {
                entity.HasKey(e => e.IdAso)
                    .IsClustered(false);

                entity.ToTable("TB_ASO");

                entity.Property(e => e.IdAso).HasColumnName("ID_ASO");

                entity.Property(e => e.CdMtrcaFncno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CD_MTRCA_FNCNO");

                entity.Property(e => e.DsAnexoAso)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DS_ANEXO_ASO");

                entity.Property(e => e.DtAso)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_ASO");

                entity.Property(e => e.IdAsoSoc).HasColumnName("ID_ASO_SOC");

                entity.Property(e => e.IdBnfco).HasColumnName("ID_BNFCO");

                entity.Property(e => e.InRsltoAso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_RSLTO_ASO")
                    .IsFixedLength();

                entity.Property(e => e.InStcoAso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_STCO_ASO")
                    .IsFixedLength();

                entity.Property(e => e.InTipoExameOcpcl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_TIPO_EXAME_OCPCL")
                    .IsFixedLength();

                entity.Property(e => e.NmMdcoEmtne)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NM_MDCO_EMTNE");

                entity.Property(e => e.NmMdcoRspnl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NM_MDCO_RSPNL");

                entity.Property(e => e.NrCpfMdcoEmtne)
                    .HasColumnType("numeric(11, 0)")
                    .HasColumnName("NR_CPF_MDCO_EMTNE");

                entity.Property(e => e.NrCpfMdcoRspnl)
                    .HasColumnType("numeric(11, 0)")
                    .HasColumnName("NR_CPF_MDCO_RSPNL");

                entity.Property(e => e.NrCrmMdcoEmtne)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("NR_CRM_MDCO_EMTNE");

                entity.Property(e => e.NrCrmMdcoRspn)
                    .HasColumnType("numeric(8, 0)")
                    .HasColumnName("NR_CRM_MDCO_RSPN");

                entity.Property(e => e.NrNisMdcoEmtne)
                    .HasColumnType("numeric(11, 0)")
                    .HasColumnName("NR_NIS_MDCO_EMTNE");

                entity.Property(e => e.SgUfCrmMdcoEmtne)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SG_UF_CRM_MDCO_EMTNE");

                entity.Property(e => e.SgUfCrmMdcoRspnl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SG_UF_CRM_MDCO_RSPNL");
            });

            modelBuilder.Entity<TbCampo>(entity =>
            {
                entity.HasKey(e => e.IdCampo)
                    .HasName("PK_ID_CAMPO")
                    .IsClustered(false);

                entity.ToTable("TB_CAMPO");

                entity.HasIndex(e => e.IdSssao, "IDX_CAMPO_ID_SSSAO");

                entity.Property(e => e.IdCampo)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CAMPO");

                entity.Property(e => e.CdAlinhaDescao)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_ALINHA_DESCAO");

                entity.Property(e => e.CdAlinhaInsto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_ALINHA_INSTO");

                entity.Property(e => e.CdCampo).HasColumnName("CD_CAMPO");

                entity.Property(e => e.IdCampoAgrtoEscal).HasColumnName("ID_CAMPO_AGRTO_ESCAL");

                entity.Property(e => e.IdCampoDataEscal).HasColumnName("ID_CAMPO_DATA_ESCAL");

                entity.Property(e => e.IdCampoObscoEscal).HasColumnName("ID_CAMPO_OBSCO_ESCAL");

                entity.Property(e => e.IdCampoOrdemExameEscal).HasColumnName("ID_CAMPO_ORDEM_EXAME_ESCAL");

                entity.Property(e => e.IdPrctoDgncoEscal).HasColumnName("ID_PRCTO_DGNCO_ESCAL");

                entity.Property(e => e.IdSssao).HasColumnName("ID_SSSAO");

                entity.Property(e => e.IdTipoIndorCampoMntto).HasColumnName("ID_TIPO_INDOR_CAMPO_MNTTO");

                entity.Property(e => e.InEnviaEscal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_ENVIA_ESCAL");

                entity.Property(e => e.InExbirDscao)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_EXBIR_DSCAO");

                entity.Property(e => e.InExibirInsto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_EXIBIR_INSTO");

                entity.Property(e => e.InObrgo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_OBRGO");

                entity.Property(e => e.InRsptaAso).HasColumnName("IN_RSPTA_ASO");

                entity.Property(e => e.InRsptaPrtte)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_RSPTA_PRTTE");

                entity.Property(e => e.InUmaOpcoLinha)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_UMA_OPCO_LINHA");

                entity.Property(e => e.NrIddeFnal).HasColumnName("NR_IDDE_FNAL");

                entity.Property(e => e.NrIddeIncal).HasColumnName("NR_IDDE_INCAL");

                entity.Property(e => e.NrOrdem).HasColumnName("NR_ORDEM");

                entity.Property(e => e.NrTmnhoDescao).HasColumnName("NR_TMNHO_DESCAO");

                entity.Property(e => e.NrTmnhoInsto).HasColumnName("NR_TMNHO_INSTO");

                entity.Property(e => e.NrTmnhoRspta).HasColumnName("NR_TMNHO_RSPTA");

                entity.Property(e => e.TpAprco).HasColumnName("TP_APRCO");

                entity.Property(e => e.TpRspta).HasColumnName("TP_RSPTA");

                entity.Property(e => e.TpSxo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TP_SXO");

                entity.Property(e => e.TxCampo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TX_CAMPO");

                entity.Property(e => e.TxInsto)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("TX_INSTO");

                entity.HasOne(d => d.IdPrctoDgncoEscalNavigation)
                    .WithMany(p => p.TbCampos)
                    .HasForeignKey(d => d.IdPrctoDgncoEscal)
                    .HasConstraintName("FK_ID_PRCTO_DGNCO_ESCAL");

                entity.HasOne(d => d.IdTipoIndorCampoMnttoNavigation)
                    .WithMany(p => p.TbCampos)
                    .HasForeignKey(d => d.IdTipoIndorCampoMntto)
                    .HasConstraintName("FK_ID_TIPO_INDOR_CAMPO_MNTTO");
            });

            modelBuilder.Entity<TbCampoOld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_CAMPO_OLD");

                entity.Property(e => e.CdAlinhaDescao)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_ALINHA_DESCAO");

                entity.Property(e => e.CdAlinhaInsto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_ALINHA_INSTO");

                entity.Property(e => e.CdCampo).HasColumnName("CD_CAMPO");

                entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");

                entity.Property(e => e.IdCampoAgrtoEscal).HasColumnName("ID_CAMPO_AGRTO_ESCAL");

                entity.Property(e => e.IdCampoDataEscal).HasColumnName("ID_CAMPO_DATA_ESCAL");

                entity.Property(e => e.IdCampoObscoEscal).HasColumnName("ID_CAMPO_OBSCO_ESCAL");

                entity.Property(e => e.IdPrctoDgncoEscal).HasColumnName("ID_PRCTO_DGNCO_ESCAL");

                entity.Property(e => e.IdSssao).HasColumnName("ID_SSSAO");

                entity.Property(e => e.IdTipoIndorCampoMntto).HasColumnName("ID_TIPO_INDOR_CAMPO_MNTTO");

                entity.Property(e => e.InEnviaEscal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_ENVIA_ESCAL");

                entity.Property(e => e.InExbirDscao)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_EXBIR_DSCAO");

                entity.Property(e => e.InExibirInsto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_EXIBIR_INSTO");

                entity.Property(e => e.InObrgo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_OBRGO");

                entity.Property(e => e.InRsptaAso).HasColumnName("IN_RSPTA_ASO");

                entity.Property(e => e.InRsptaPrtte)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_RSPTA_PRTTE");

                entity.Property(e => e.InUmaOpcoLinha)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_UMA_OPCO_LINHA");

                entity.Property(e => e.NrIddeFnal).HasColumnName("NR_IDDE_FNAL");

                entity.Property(e => e.NrIddeIncal).HasColumnName("NR_IDDE_INCAL");

                entity.Property(e => e.NrOrdem).HasColumnName("NR_ORDEM");

                entity.Property(e => e.NrTmnhoDescao).HasColumnName("NR_TMNHO_DESCAO");

                entity.Property(e => e.NrTmnhoInsto).HasColumnName("NR_TMNHO_INSTO");

                entity.Property(e => e.NrTmnhoRspta).HasColumnName("NR_TMNHO_RSPTA");

                entity.Property(e => e.TpAprco).HasColumnName("TP_APRCO");

                entity.Property(e => e.TpRspta).HasColumnName("TP_RSPTA");

                entity.Property(e => e.TpSxo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TP_SXO");

                entity.Property(e => e.TxCampo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TX_CAMPO");

                entity.Property(e => e.TxInsto)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("TX_INSTO");
            });

            modelBuilder.Entity<TbClna>(entity =>
            {
                entity.HasKey(e => e.IdClnas)
                    .HasName("PK_ID_CLNAS")
                    .IsClustered(false);

                entity.ToTable("TB_CLNAS");

                entity.HasIndex(e => e.IdCampo, "IDX_CLONAS_ID_CAMPO");

                entity.Property(e => e.IdClnas)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CLNAS");

                entity.Property(e => e.CdAlnha)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_ALNHA");

                entity.Property(e => e.CdClnas).HasColumnName("CD_CLNAS");

                entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");

                entity.Property(e => e.InExbir)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_EXBIR");

                entity.Property(e => e.InRsptaPrtte)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_RSPTA_PRTTE");

                entity.Property(e => e.InUmaOpcoLinha)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_UMA_OPCO_LINHA");

                entity.Property(e => e.NrOrdem).HasColumnName("NR_ORDEM");

                entity.Property(e => e.NrTmnho).HasColumnName("NR_TMNHO");

                entity.Property(e => e.TpOpcao).HasColumnName("TP_OPCAO");

                entity.Property(e => e.TxClnas)
                    .HasMaxLength(900)
                    .IsUnicode(false)
                    .HasColumnName("TX_CLNAS");

                entity.Property(e => e.VlMax)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VL_MAX");

                entity.Property(e => e.VlMin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VL_MIN");
            });

            modelBuilder.Entity<TbClnasOld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_CLNAS_OLD");

                entity.HasIndex(e => e.IdCampo, "IDX_CLONAS_ID_CAMPO");

                entity.Property(e => e.CdAlnha)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_ALNHA");

                entity.Property(e => e.CdClnas).HasColumnName("CD_CLNAS");

                entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");

                entity.Property(e => e.IdClnas).HasColumnName("ID_CLNAS");

                entity.Property(e => e.InExbir)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_EXBIR");

                entity.Property(e => e.InRsptaPrtte)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_RSPTA_PRTTE");

                entity.Property(e => e.InUmaOpcoLinha)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_UMA_OPCO_LINHA");

                entity.Property(e => e.NrOrdem).HasColumnName("NR_ORDEM");

                entity.Property(e => e.NrTmnho).HasColumnName("NR_TMNHO");

                entity.Property(e => e.TpOpcao).HasColumnName("TP_OPCAO");

                entity.Property(e => e.TxClnas)
                    .HasMaxLength(900)
                    .IsUnicode(false)
                    .HasColumnName("TX_CLNAS");

                entity.Property(e => e.VlMax)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VL_MAX");

                entity.Property(e => e.VlMin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VL_MIN");
            });

            modelBuilder.Entity<TbDpdca>(entity =>
            {
                entity.HasKey(e => e.IdDpdca)
                    .HasName("PK_ID_DPDCA")
                    .IsClustered(false);

                entity.ToTable("TB_DPDCA");

                entity.HasIndex(e => e.IdCampo, "IDX_DPDCA_ID_CAMPO");

                entity.HasIndex(e => e.IdDpdcaCampo, "IDX_DPDCA_ID_DPDCA_CAMPO");

                entity.HasIndex(e => e.IdOpcao, "IDX_DPDCA_ID_OPCAO");

                entity.Property(e => e.IdDpdca).HasColumnName("ID_DPDCA");

                entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");

                entity.Property(e => e.IdDpdcaCampo).HasColumnName("ID_DPDCA_CAMPO");

                entity.Property(e => e.IdOpcao).HasColumnName("ID_OPCAO");
            });

            modelBuilder.Entity<TbDpdcaFrmro>(entity =>
            {
                entity.HasKey(e => e.IdDpdca)
                    .HasName("PK__TB_DPDCA__1A6511F7E43DA679");

                entity.ToTable("TB_DPDCA_FRMRO");

                entity.HasIndex(e => e.IdOpcao, "IDX_DPDCA_FRMRO_ID_OPCAO");

                entity.Property(e => e.IdDpdca).HasColumnName("ID_DPDCA");

                entity.Property(e => e.IdCampoDpdca).HasColumnName("ID_CAMPO_DPDCA");

                entity.Property(e => e.IdFrmro).HasColumnName("ID_FRMRO");

                entity.Property(e => e.IdFrmroDpdca).HasColumnName("ID_FRMRO_DPDCA");

                entity.Property(e => e.IdOpcao).HasColumnName("ID_OPCAO");

                entity.Property(e => e.IdOpcaoDpdca).HasColumnName("ID_OPCAO_DPDCA");

                entity.Property(e => e.IdSssao).HasColumnName("ID_SSSAO");

                entity.Property(e => e.IdSssaoDpdca).HasColumnName("ID_SSSAO_DPDCA");

                entity.Property(e => e.InMnsgmInfro).HasColumnName("IN_MNSGM_INFRO");

                entity.Property(e => e.TipRfrnaVnclo).HasColumnName("TIP_RFRNA_VNCLO");

                entity.Property(e => e.TxAco)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_ACO");

                entity.Property(e => e.TxMnsgmNtfco)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TX_MNSGM_NTFCO");
            });

            modelBuilder.Entity<TbEnvioMntto>(entity =>
            {
                entity.HasKey(e => e.IdEnvioMntto)
                    .HasName("PK_ID_ENVIO_MNTTO")
                    .IsClustered(false);

                entity.ToTable("TB_ENVIO_MNTTO");

                entity.Property(e => e.IdEnvioMntto).HasColumnName("ID_ENVIO_MNTTO");

                entity.Property(e => e.DtIncsoRgsto)
                    .HasColumnType("date")
                    .HasColumnName("DT_INCSO_RGSTO");

                entity.Property(e => e.IdRsptaFrmroAso).HasColumnName("ID_RSPTA_FRMRO_ASO");

                entity.Property(e => e.IdRsptaFrmroPrpal).HasColumnName("ID_RSPTA_FRMRO_PRPAL");

                entity.Property(e => e.IdStcaoEnvioMntto).HasColumnName("ID_STCAO_ENVIO_MNTTO");

                entity.Property(e => e.IdTipoExameOcpal).HasColumnName("ID_TIPO_EXAME_OCPAL");

                entity.Property(e => e.NmFncro)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NM_FNCRO");

                entity.Property(e => e.NrMtclaFncal)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NR_MTCLA_FNCAL");

                entity.Property(e => e.SeqExameBb).HasColumnName("SEQ_EXAME_BB");

                entity.HasOne(d => d.IdRsptaFrmroAsoNavigation)
                    .WithMany(p => p.TbEnvioMnttoIdRsptaFrmroAsoNavigations)
                    .HasForeignKey(d => d.IdRsptaFrmroAso)
                    .HasConstraintName("FK_ID_RSPTA_FRMRO_ASO");

                entity.HasOne(d => d.IdRsptaFrmroPrpalNavigation)
                    .WithMany(p => p.TbEnvioMnttoIdRsptaFrmroPrpalNavigations)
                    .HasForeignKey(d => d.IdRsptaFrmroPrpal)
                    .HasConstraintName("FK_ID_RSPTA_FRMRO_PRPAL");

                entity.HasOne(d => d.IdStcaoEnvioMnttoNavigation)
                    .WithMany(p => p.TbEnvioMnttos)
                    .HasForeignKey(d => d.IdStcaoEnvioMntto)
                    .HasConstraintName("FK_ID_STCAO_ENVIO_MNTTO");

                entity.HasOne(d => d.IdTipoExameOcpalNavigation)
                    .WithMany(p => p.TbEnvioMnttos)
                    .HasForeignKey(d => d.IdTipoExameOcpal)
                    .HasConstraintName("FK_ID_TIPO_EXAME_OCPAL");
            });

            modelBuilder.Entity<TbEnvioMnttoAso>(entity =>
            {
                entity.HasKey(e => e.IdEnvioMnttoAso)
                    .HasName("PK_ID_ENVIO_MNTTO_ASO")
                    .IsClustered(false);

                entity.ToTable("TB_ENVIO_MNTTO_ASO");

                entity.Property(e => e.IdEnvioMnttoAso).HasColumnName("ID_ENVIO_MNTTO_ASO");

                entity.Property(e => e.DtEmsaoAso)
                    .HasColumnType("date")
                    .HasColumnName("DT_EMSAO_ASO");

                entity.Property(e => e.DtExame)
                    .HasColumnType("date")
                    .HasColumnName("DT_EXAME");

                entity.Property(e => e.IdArqvo).HasColumnName("ID_ARQVO");

                entity.Property(e => e.IdEnvioMntto).HasColumnName("ID_ENVIO_MNTTO");

                entity.Property(e => e.IdRsptaFrmroAso).HasColumnName("ID_RSPTA_FRMRO_ASO");

                entity.Property(e => e.IdTipoRstdoAso).HasColumnName("ID_TIPO_RSTDO_ASO");

                entity.Property(e => e.NmMdicoCddorPcmso)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NM_MDICO_CDDOR_PCMSO");

                entity.Property(e => e.NmMdicoEmtteAso)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NM_MDICO_EMTTE_ASO");

                entity.Property(e => e.NrCpfMdicoCddorPcmso)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("NR_CPF_MDICO_CDDOR_PCMSO");

                entity.Property(e => e.NrCrmMdicoCddorPcmso)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NR_CRM_MDICO_CDDOR_PCMSO");

                entity.Property(e => e.NrCrmMdicoEmtteAso)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NR_CRM_MDICO_EMTTE_ASO");

                entity.Property(e => e.SgUfCrmMdicoCddorPcmso)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SG_UF_CRM_MDICO_CDDOR_PCMSO");

                entity.Property(e => e.SgUfCrmMdicoEmtteAso)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SG_UF_CRM_MDICO_EMTTE_ASO");

                entity.HasOne(d => d.IdArqvoNavigation)
                    .WithMany(p => p.TbEnvioMnttoAsos)
                    .HasForeignKey(d => d.IdArqvo)
                    .HasConstraintName("FK_ID_ARQVO_TB_ARQVO");

                entity.HasOne(d => d.IdEnvioMnttoNavigation)
                    .WithMany(p => p.TbEnvioMnttoAsos)
                    .HasForeignKey(d => d.IdEnvioMntto)
                    .HasConstraintName("FK_ID_ENVIO_MNTTO_ASO");

                entity.HasOne(d => d.IdTipoRstdoAsoNavigation)
                    .WithMany(p => p.TbEnvioMnttoAsos)
                    .HasForeignKey(d => d.IdTipoRstdoAso)
                    .HasConstraintName("FK_ID_TIPO_RSTDO_ASO");
            });

            modelBuilder.Entity<TbEnvioMnttoAsoExame>(entity =>
            {
                entity.HasKey(e => e.IdEnvioMnttoAsoExame)
                    .HasName("PK_ID_ENVIO_MNTTO_ASO_EXAME")
                    .IsClustered(false);

                entity.ToTable("TB_ENVIO_MNTTO_ASO_EXAME");

                entity.Property(e => e.IdEnvioMnttoAsoExame).HasColumnName("ID_ENVIO_MNTTO_ASO_EXAME");

                entity.Property(e => e.CdOrdemExame).HasColumnName("CD_ORDEM_EXAME");

                entity.Property(e => e.CdPrctoDgncoEscal)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CD_PRCTO_DGNCO_ESCAL");

                entity.Property(e => e.DsRspta)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DS_RSPTA");

                entity.Property(e => e.DtExame)
                    .HasColumnType("date")
                    .HasColumnName("DT_EXAME");

                entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");

                entity.Property(e => e.IdEnvioMnttoAso).HasColumnName("ID_ENVIO_MNTTO_ASO");

                entity.Property(e => e.IdPrctoDgncoEscal).HasColumnName("ID_PRCTO_DGNCO_ESCAL");

                entity.Property(e => e.IdTipoRstdoExame).HasColumnName("ID_TIPO_RSTDO_EXAME");

                entity.Property(e => e.VlRspta).HasColumnName("VL_RSPTA");

                entity.HasOne(d => d.IdCampoNavigation)
                    .WithMany(p => p.TbEnvioMnttoAsoExames)
                    .HasForeignKey(d => d.IdCampo)
                    .HasConstraintName("FK_ID_CAMPO_ASO_EXAME");

                entity.HasOne(d => d.IdEnvioMnttoAsoNavigation)
                    .WithMany(p => p.TbEnvioMnttoAsoExames)
                    .HasForeignKey(d => d.IdEnvioMnttoAso)
                    .HasConstraintName("FK_ID_ENVIO_MNTTO_ASO_EXAME");

                entity.HasOne(d => d.IdPrctoDgncoEscalNavigation)
                    .WithMany(p => p.TbEnvioMnttoAsoExames)
                    .HasForeignKey(d => d.IdPrctoDgncoEscal)
                    .HasConstraintName("FK_ID_PRCTO_DGNCO_ESCA");

                entity.HasOne(d => d.IdTipoRstdoExameNavigation)
                    .WithMany(p => p.TbEnvioMnttoAsoExames)
                    .HasForeignKey(d => d.IdTipoRstdoExame)
                    .HasConstraintName("FK_ID_TIPO_RSTDO_EXAME");
            });

            modelBuilder.Entity<TbEnvioMnttoHstcoStcao>(entity =>
            {
                entity.HasKey(e => e.IdEnvioMnttoHstcoStcao)
                    .HasName("PK_ID_ENVIO_MNTTO_HSTCO_STCAO")
                    .IsClustered(false);

                entity.ToTable("TB_ENVIO_MNTTO_HSTCO_STCAO");

                entity.Property(e => e.IdEnvioMnttoHstcoStcao).HasColumnName("ID_ENVIO_MNTTO_HSTCO_STCAO");

                entity.Property(e => e.DsOcrca)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DS_OCRCA");

                entity.Property(e => e.DtEnvio)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_ENVIO");

                entity.Property(e => e.IdEnvioMntto).HasColumnName("ID_ENVIO_MNTTO");

                entity.Property(e => e.IdStcaoEnvioMntto).HasColumnName("ID_STCAO_ENVIO_MNTTO");

                entity.HasOne(d => d.IdEnvioMnttoNavigation)
                    .WithMany(p => p.TbEnvioMnttoHstcoStcaos)
                    .HasForeignKey(d => d.IdEnvioMntto)
                    .HasConstraintName("FK_ID_ENVIO_MNTTO_HSTCO_STCAO");

                entity.HasOne(d => d.IdStcaoEnvioMnttoNavigation)
                    .WithMany(p => p.TbEnvioMnttoHstcoStcaos)
                    .HasForeignKey(d => d.IdStcaoEnvioMntto)
                    .HasConstraintName("FK_ID_STCAO_ENVIO_MNTTO_HSTCO_STCAO");
            });

            modelBuilder.Entity<TbExptaFrmro>(entity =>
            {
                entity.HasKey(e => e.IdExpta)
                    .HasName("PK__TB_EXPTA__03A1712E4AF97773");

                entity.ToTable("TB_EXPTA_FRMRO");

                entity.Property(e => e.IdExpta).HasColumnName("ID_EXPTA");

                entity.Property(e => e.CdFrmro).HasColumnName("CD_FRMRO");

                entity.Property(e => e.IdFrmro).HasColumnName("ID_FRMRO");

                entity.Property(e => e.IdOpcao).HasColumnName("ID_OPCAO");

                entity.Property(e => e.IdSessao).HasColumnName("ID_SESSAO");

                entity.Property(e => e.InPscaoX).HasColumnName("IN_PSCAO_X");

                entity.Property(e => e.InPscaoY).HasColumnName("IN_PSCAO_Y");

                entity.Property(e => e.TxCampo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_CAMPO");
            });

            modelBuilder.Entity<TbFrmro>(entity =>
            {
                entity.HasKey(e => e.IdFrmro)
                    .HasName("PK_ID_FRMRO")
                    .IsClustered(false);

                entity.ToTable("TB_FRMRO");

                entity.Property(e => e.IdFrmro)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_FRMRO");

                entity.Property(e => e.CdFrmro).HasColumnName("CD_FRMRO");

                entity.Property(e => e.DtFinal)
                    .HasColumnType("date")
                    .HasColumnName("DT_FINAL");

                entity.Property(e => e.DtInial)
                    .HasColumnType("date")
                    .HasColumnName("DT_INIAL");

                entity.Property(e => e.ExDpdca)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EX_DPDCA")
                    .IsFixedLength();

                entity.Property(e => e.IdEmpsa).HasColumnName("ID_EMPSA");

                entity.Property(e => e.NrAno).HasColumnName("NR_ANO");

                entity.Property(e => e.StFrmro)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ST_FRMRO");

                entity.Property(e => e.TpFrmro).HasColumnName("TP_FRMRO");

                entity.Property(e => e.TxFrmro)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TX_FRMRO");
            });

            modelBuilder.Entity<TbFrmroLog>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PK__TB_FRMRO__2DBE379DE9C48265");

                entity.ToTable("TB_FRMRO_LOG");

                entity.Property(e => e.IdLog).HasColumnName("ID_LOG");

                entity.Property(e => e.DtAltco)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_ALTCO");

                entity.Property(e => e.IdFrmroDe).HasColumnName("ID_FRMRO_DE");

                entity.Property(e => e.IdFrmroPara).HasColumnName("ID_FRMRO_PARA");

                entity.Property(e => e.IdUsrioAltco).HasColumnName("ID_USRIO_ALTCO");

                entity.Property(e => e.NmUsrioAltco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NM_USRIO_ALTCO");

                entity.Property(e => e.TxAcao)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TX_ACAO");
            });

            modelBuilder.Entity<TbFrmroOld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_FRMRO_OLD");

                entity.Property(e => e.CdFrmro).HasColumnName("CD_FRMRO");

                entity.Property(e => e.DtFinal)
                    .HasColumnType("date")
                    .HasColumnName("DT_FINAL");

                entity.Property(e => e.DtInial)
                    .HasColumnType("date")
                    .HasColumnName("DT_INIAL");

                entity.Property(e => e.ExDpdca)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EX_DPDCA")
                    .IsFixedLength();

                entity.Property(e => e.IdEmpsa).HasColumnName("ID_EMPSA");

                entity.Property(e => e.IdFrmro).HasColumnName("ID_FRMRO");

                entity.Property(e => e.NrAno).HasColumnName("NR_ANO");

                entity.Property(e => e.StFrmro)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ST_FRMRO");

                entity.Property(e => e.TpFrmro).HasColumnName("TP_FRMRO");

                entity.Property(e => e.TxFrmro)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TX_FRMRO");
            });

            modelBuilder.Entity<TbLogPrmtoFrmlo>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PK__TB_LOG_P__2DBE379D00A39116");

                entity.ToTable("TB_LOG_PRMTO_FRMLO");

                entity.Property(e => e.IdLog).HasColumnName("ID_LOG");

                entity.Property(e => e.DtRegto)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_REGTO");

                entity.Property(e => e.IdBnfro).HasColumnName("ID_BNFRO");

                entity.Property(e => e.IdFrmro).HasColumnName("ID_FRMRO");

                entity.Property(e => e.IdRspstaFrmro).HasColumnName("ID_RSPSTA_FRMRO");

                entity.Property(e => e.IdUsudgt).HasColumnName("ID_USUDGT");

                entity.Property(e => e.StcaoFrmroRspsta)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STCAO_FRMRO_RSPSTA");

                entity.Property(e => e.TxStcao)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TX_STCAO");

                entity.Property(e => e.TxUsudgt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TX_USUDGT");
            });

            modelBuilder.Entity<TbMdico>(entity =>
            {
                entity.HasKey(e => e.IdMdico)
                    .HasName("PK__TB_MDICO__D1B1E50F58FB86E2");

                entity.ToTable("TB_MDICO");

                entity.Property(e => e.IdMdico).HasColumnName("ID_MDICO");

                entity.Property(e => e.DtCdtro)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_CDTRO");

                entity.Property(e => e.NmMdico)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NM_MDICO");

                entity.Property(e => e.NrCpf)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NR_CPF");

                entity.Property(e => e.NrCrm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NR_CRM");

                entity.Property(e => e.OrgemCdtro)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ORGEM_CDTRO");

                entity.Property(e => e.SgUfCrm)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SG_UF_CRM");
            });

            modelBuilder.Entity<TbOpcao>(entity =>
            {
                entity.HasKey(e => e.IdOpcao)
                    .HasName("PK_ID_OPCAO")
                    .IsClustered(false);

                entity.ToTable("TB_OPCAO");

                entity.HasIndex(e => e.IdClnas, "IDX_TB_OPCAO_ID_CLNAS");

                entity.Property(e => e.IdOpcao)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_OPCAO");

                entity.Property(e => e.ExDpdca)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EX_DPDCA")
                    .IsFixedLength();

                entity.Property(e => e.ExVlorOpc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EX_VLOR_OPC")
                    .IsFixedLength();

                entity.Property(e => e.IdClnas).HasColumnName("ID_CLNAS");

                entity.Property(e => e.NrCasasDcmis).HasColumnName("NR_CASAS_DCMIS");

                entity.Property(e => e.NrMaxCrtes).HasColumnName("NR_MAX_CRTES");

                entity.Property(e => e.NrOrdem).HasColumnName("NR_ORDEM");

                entity.Property(e => e.NrValor)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("NR_VALOR");

                entity.Property(e => e.TxLgnda)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TX_LGNDA");

                entity.Property(e => e.VlIndcoRsldoEscal).HasColumnName("VL_INDCO_RSLDO_ESCAL");

                entity.Property(e => e.VlMnimo).HasColumnName("VL_MNIMO");

                entity.Property(e => e.VlMximo).HasColumnName("VL_MXIMO");
            });

            modelBuilder.Entity<TbOpcaoOld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_OPCAO_OLD");

                entity.Property(e => e.ExDpdca)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EX_DPDCA")
                    .IsFixedLength();

                entity.Property(e => e.ExVlorOpc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EX_VLOR_OPC")
                    .IsFixedLength();

                entity.Property(e => e.IdClnas).HasColumnName("ID_CLNAS");

                entity.Property(e => e.IdOpcao).HasColumnName("ID_OPCAO");

                entity.Property(e => e.NrCasasDcmis).HasColumnName("NR_CASAS_DCMIS");

                entity.Property(e => e.NrMaxCrtes).HasColumnName("NR_MAX_CRTES");

                entity.Property(e => e.NrOrdem).HasColumnName("NR_ORDEM");

                entity.Property(e => e.NrValor)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("NR_VALOR");

                entity.Property(e => e.TxLgnda)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TX_LGNDA");

                entity.Property(e => e.VlIndcoRsldoEscal).HasColumnName("VL_INDCO_RSLDO_ESCAL");

                entity.Property(e => e.VlMnimo).HasColumnName("VL_MNIMO");

                entity.Property(e => e.VlMximo).HasColumnName("VL_MXIMO");
            });

            modelBuilder.Entity<TbOrdem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_ORDEM");

                entity.Property(e => e.CdOrdem).HasColumnName("CD_ORDEM");

                entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");

                entity.Property(e => e.IdFrmro).HasColumnName("ID_FRMRO");
            });

            modelBuilder.Entity<TbPrcdoDgnso>(entity =>
            {
                entity.HasKey(e => e.IdPrcdoDgnso)
                    .IsClustered(false);

                entity.ToTable("TB_PRCDO_DGNSO");

                entity.Property(e => e.IdPrcdoDgnso).HasColumnName("ID_PRCDO_DGNSO");

                entity.Property(e => e.DsObsroPrcdoDgnso)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DS_OBSRO_PRCDO_DGNSO");

                entity.Property(e => e.DtExame)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_EXAME");

                entity.Property(e => e.IdAso).HasColumnName("ID_ASO");

                entity.Property(e => e.IdPrcdoDgnsoEscl).HasColumnName("ID_PRCDO_DGNSO_ESCL");

                entity.Property(e => e.InOrdemExame)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_ORDEM_EXAME")
                    .IsFixedLength();

                entity.Property(e => e.InRslto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IN_RSLTO")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbPrcdoDgnsoEscl>(entity =>
            {
                entity.HasKey(e => e.IdPrcdoDgnsoEscl)
                    .IsClustered(false);

                entity.ToTable("TB_PRCDO_DGNSO_ESCL");

                entity.Property(e => e.IdPrcdoDgnsoEscl).HasColumnName("ID_PRCDO_DGNSO_ESCL");

                entity.Property(e => e.CdPrcdoDgnsoEscl)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CD_PRCDO_DGNSO_ESCL");

                entity.Property(e => e.DsPrcdoDgnsoEscl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DS_PRCDO_DGNSO_ESCL");

                entity.Property(e => e.DtFimVgnca)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_FIM_VGNCA");

                entity.Property(e => e.DtIncoVgnca)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_INCO_VGNCA");
            });

            modelBuilder.Entity<TbPrctoDgncoEscal>(entity =>
            {
                entity.HasKey(e => e.IdPrctoDgncoEscal)
                    .HasName("PK_ID_PRCTO_DGNCO_ESCAL")
                    .IsClustered(false);

                entity.ToTable("TB_PRCTO_DGNCO_ESCAL");

                entity.Property(e => e.IdPrctoDgncoEscal).HasColumnName("ID_PRCTO_DGNCO_ESCAL");

                entity.Property(e => e.CdPrctoDgncoEscal)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CD_PRCTO_DGNCO_ESCAL");

                entity.Property(e => e.DsPrctoDgncoEscal)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DS_PRCTO_DGNCO_ESCAL");

                entity.Property(e => e.DtFimVgcia)
                    .HasColumnType("date")
                    .HasColumnName("DT_FIM_VGCIA");

                entity.Property(e => e.DtIncioVgcia)
                    .HasColumnType("date")
                    .HasColumnName("DT_INCIO_VGCIA");

                entity.Property(e => e.InFvrto).HasColumnName("IN_FVRTO");
            });

            modelBuilder.Entity<TbPrmtoFrmloPrcdoDgnso>(entity =>
            {
                entity.HasKey(e => e.IdPrmtoFrmloPrcdoDgnso)
                    .IsClustered(false);

                entity.ToTable("TB_PRMTO_FRMLO_PRCDO_DGNSO");

                entity.Property(e => e.IdPrmtoFrmloPrcdoDgnso).HasColumnName("ID_PRMTO_FRMLO_PRCDO_DGNSO");

                entity.Property(e => e.DtFimVgnca)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_FIM_VGNCA");

                entity.Property(e => e.DtIncoVgnca)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_INCO_VGNCA");

                entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");

                entity.Property(e => e.IdPrcdoDgnsoEscl).HasColumnName("ID_PRCDO_DGNSO_ESCL");
            });

            modelBuilder.Entity<TbRsptaCampo>(entity =>
            {
                entity.HasKey(e => e.IdRsptaCampo)
                    .HasName("PK_ID_RSPTA_CAMPO")
                    .IsClustered(false);

                entity.ToTable("TB_RSPTA_CAMPO");

                entity.HasIndex(e => new { e.IdRsptaFrmro, e.IdSssao },
                        "01-02-2022_IX_TB_RSPTA_CAMPO_ID_RSPTA_FRMRO_ID_SSSAO")
                    .HasFillFactor(80);

                entity.HasIndex(e => new { e.IdSssao, e.IdBnfro }, "IDX_IDSSSAO");

                entity.Property(e => e.IdRsptaCampo).HasColumnName("ID_RSPTA_CAMPO");

                entity.Property(e => e.IdBnfro).HasColumnName("ID_BNFRO");

                entity.Property(e => e.IdCampo).HasColumnName("ID_CAMPO");

                entity.Property(e => e.IdRsptaFrmro).HasColumnName("ID_RSPTA_FRMRO");

                entity.Property(e => e.IdSssao).HasColumnName("ID_SSSAO");

                entity.Property(e => e.VlRspta).HasColumnName("VL_RSPTA");
            });

            modelBuilder.Entity<TbRsptaFrmro>(entity =>
            {
                entity.HasKey(e => e.IdRsptaFrmro)
                    .HasName("PK_ID_RSPTA_FRMRO")
                    .IsClustered(false);

                entity.ToTable("TB_RSPTA_FRMRO");

                entity.HasIndex(e => new { e.IdFrmro, e.IdBnfro }, "01-02-2022_IX_TB_RSPTA_FRMRO_ID_FRMRO_ID_BNFRO")
                    .HasFillFactor(80);

                entity.Property(e => e.IdRsptaFrmro).HasColumnName("ID_RSPTA_FRMRO");

                entity.Property(e => e.DtAltco)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_ALTCO");

                entity.Property(e => e.DtExame)
                    .HasColumnType("date")
                    .HasColumnName("DT_EXAME");

                entity.Property(e => e.DtIncso)
                    .HasColumnType("date")
                    .HasColumnName("DT_INCSO");

                entity.Property(e => e.IdBnfro).HasColumnName("ID_BNFRO");

                entity.Property(e => e.IdCargo).HasColumnName("ID_CARGO");

                entity.Property(e => e.IdCntto).HasColumnName("ID_CNTTO");

                entity.Property(e => e.IdExme).HasColumnName("ID_EXME");

                entity.Property(e => e.IdFrmro).HasColumnName("ID_FRMRO");

                entity.Property(e => e.IdLtcao).HasColumnName("ID_LTCAO");

                entity.Property(e => e.IdMdico).HasColumnName("ID_MDICO");

                entity.Property(e => e.IdRsptaFrmroPrnpl).HasColumnName("ID_RSPTA_FRMRO_PRNPL");

                entity.Property(e => e.IdUsrioAltco).HasColumnName("ID_USRIO_ALTCO");

                entity.Property(e => e.IdUsudgt).HasColumnName("ID_USUDGT");

                entity.Property(e => e.InEmpsa).HasColumnName("IN_EMPSA");

                entity.Property(e => e.InStcao).HasColumnName("IN_STCAO");

                entity.Property(e => e.InStcaoSoc).HasColumnName("IN_STCAO_SOC");

                entity.Property(e => e.InTipoUsrioDgtco).HasColumnName("IN_TIPO_USRIO_DGTCO");

                entity.Property(e => e.LoginUsrioAltco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN_USRIO_ALTCO");

                entity.Property(e => e.LoginUsrioDgtco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN_USRIO_DGTCO");

                entity.Property(e => e.NmBnfro)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("NM_BNFRO");

                entity.Property(e => e.NomeUsrioAltco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME_USRIO_ALTCO");

                entity.Property(e => e.NomeUsrioDgtco)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME_USRIO_DGTCO");

                entity.Property(e => e.NrCnpj)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NR_CNPJ");

                entity.Property(e => e.NrCpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("NR_CPF");

                entity.Property(e => e.NrMtrla)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NR_MTRLA");

                entity.Property(e => e.NrRg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NR_RG");

                entity.Property(e => e.NrTlfne)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NR_TLFNE");

                entity.Property(e => e.NrUor).HasColumnName("NR_UOR");

                entity.Property(e => e.SgUf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SG_UF");

                entity.Property(e => e.VrTempoFncao).HasColumnName("VR_TEMPO_FNCAO");
            });

            modelBuilder.Entity<TbRsptaFrmroMdico>(entity =>
            {
                entity.HasKey(e => e.IdRsptaFrmroMdico)
                    .HasName("PK_ID_RSPTA_FRMRO_MDICO")
                    .IsClustered(false);

                entity.ToTable("TB_RSPTA_FRMRO_MDICO");

                entity.Property(e => e.IdRsptaFrmroMdico).HasColumnName("ID_RSPTA_FRMRO_MDICO");

                entity.Property(e => e.IdRsptaFrmro).HasColumnName("ID_RSPTA_FRMRO");

                entity.Property(e => e.IdTipoMdico).HasColumnName("ID_TIPO_MDICO");

                entity.Property(e => e.NmMdico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NM_MDICO");

                entity.Property(e => e.NrCpf)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NR_CPF");

                entity.Property(e => e.NrCrm)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NR_CRM");

                entity.Property(e => e.SgUfCrm)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SG_UF_CRM");

                entity.HasOne(d => d.IdRsptaFrmroNavigation)
                    .WithMany(p => p.TbRsptaFrmroMdicos)
                    .HasForeignKey(d => d.IdRsptaFrmro)
                    .HasConstraintName("FK_ID_RSPTA_FRMRO_MDICO");
            });

            modelBuilder.Entity<TbRsptaLog>(entity =>
            {
                entity.HasKey(e => e.IdRsptaLog);

                entity.ToTable("TB_RSPTA_LOG");

                entity.Property(e => e.IdRsptaLog).HasColumnName("ID_RSPTA_LOG");

                entity.Property(e => e.DtPrec)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_PREC");

                entity.Property(e => e.IdBnfro).HasColumnName("ID_BNFRO");

                entity.Property(e => e.IdFrmro).HasColumnName("ID_FRMRO");

                entity.Property(e => e.IdSssao).HasColumnName("ID_SSSAO");
            });

            modelBuilder.Entity<TbRsptaOpcao>(entity =>
            {
                entity.HasKey(e => e.IdRsptaOpcao)
                    .HasName("PK_ID_RSPTA_OPCAO")
                    .IsClustered(false);

                entity.ToTable("TB_RSPTA_OPCAO");

                entity.HasIndex(e => new { e.IdSssao, e.IdBnfro }, "IDX_SSSAO_BNFRO");

                entity.Property(e => e.IdRsptaOpcao).HasColumnName("ID_RSPTA_OPCAO");

                entity.Property(e => e.IdBnfro).HasColumnName("ID_BNFRO");

                entity.Property(e => e.IdOpcao).HasColumnName("ID_OPCAO");

                entity.Property(e => e.IdRsptaCampo).HasColumnName("ID_RSPTA_CAMPO");

                entity.Property(e => e.IdSssao).HasColumnName("ID_SSSAO");

                entity.Property(e => e.TxJstva)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("TX_JSTVA");

                entity.Property(e => e.TxObsco)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("TX_OBSCO");

                entity.Property(e => e.VlRspta).HasColumnName("VL_RSPTA");
            });

            modelBuilder.Entity<TbSssao>(entity =>
            {
                entity.HasKey(e => e.IdSssao)
                    .HasName("PK_ID_SSSAO")
                    .IsClustered(false);

                entity.ToTable("TB_SSSAO");

                entity.Property(e => e.IdSssao)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_SSSAO");

                entity.Property(e => e.IdFrmro).HasColumnName("ID_FRMRO");

                entity.Property(e => e.IdSssaoPai).HasColumnName("ID_SSSAO_PAI");

                entity.Property(e => e.NrOrdem).HasColumnName("NR_ORDEM");

                entity.Property(e => e.TipPrncoUsro).HasColumnName("TIP_PRNCO_USRO");

                entity.Property(e => e.TpSssao).HasColumnName("TP_SSSAO");

                entity.Property(e => e.TpSssaoChckEps).HasColumnName("TP_SSSAO_CHCK_EPS");

                entity.Property(e => e.TpSssaoSxo).HasColumnName("TP_SSSAO_SXO");

                entity.Property(e => e.TxSssao)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TX_SSSAO");
            });

            modelBuilder.Entity<TbSssaoOld>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_SSSAO_OLD");

                entity.Property(e => e.IdFrmro).HasColumnName("ID_FRMRO");

                entity.Property(e => e.IdSssao).HasColumnName("ID_SSSAO");

                entity.Property(e => e.IdSssaoPai).HasColumnName("ID_SSSAO_PAI");

                entity.Property(e => e.NrOrdem).HasColumnName("NR_ORDEM");

                entity.Property(e => e.TipPrncoUsro).HasColumnName("TIP_PRNCO_USRO");

                entity.Property(e => e.TpSssao).HasColumnName("TP_SSSAO");

                entity.Property(e => e.TpSssaoChckEps).HasColumnName("TP_SSSAO_CHCK_EPS");

                entity.Property(e => e.TpSssaoSxo).HasColumnName("TP_SSSAO_SXO");

                entity.Property(e => e.TxSssao)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TX_SSSAO");
            });

            modelBuilder.Entity<TbStcaoEnvioMntto>(entity =>
            {
                entity.HasKey(e => e.IdStcaoEnvioMntto)
                    .HasName("PK_ID_STCAO_ENVIO_MNTTO")
                    .IsClustered(false);

                entity.ToTable("TB_STCAO_ENVIO_MNTTO");

                entity.Property(e => e.IdStcaoEnvioMntto).HasColumnName("ID_STCAO_ENVIO_MNTTO");

                entity.Property(e => e.DsStcaoEnvioMntto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DS_STCAO_ENVIO_MNTTO");
            });

            modelBuilder.Entity<TbStcoFrmro>(entity =>
            {
                entity.HasKey(e => e.IdStcoFrmro)
                    .HasName("PK__TB_STCO___6AD2FA0E6F59FAA7");

                entity.ToTable("TB_STCO_FRMRO");

                entity.Property(e => e.IdStcoFrmro).HasColumnName("ID_STCO_FRMRO");

                entity.Property(e => e.CdStco).HasColumnName("CD_STCO");

                entity.Property(e => e.TxStco)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_STCO");
            });

            modelBuilder.Entity<TbStcoTrnsa>(entity =>
            {
                entity.HasKey(e => e.IdStcoTrnsa)
                    .IsClustered(false);

                entity.ToTable("TB_STCO_TRNSA");

                entity.Property(e => e.IdStcoTrnsa).HasColumnName("ID_STCO_TRNSA");

                entity.Property(e => e.DsStcoTrnsa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DS_STCO_TRNSA");
            });

            modelBuilder.Entity<TbTestefila>(entity =>
            {
                entity.HasKey(e => e.IdTestefila)
                    .HasName("PK_ID_TESTEFILA")
                    .IsClustered(false);

                entity.ToTable("TB_TESTEFILA");

                entity.Property(e => e.IdTestefila).HasColumnName("ID_TESTEFILA");

                entity.Property(e => e.Handlesoc).HasColumnName("HANDLESOC");

                entity.Property(e => e.Textsoc)
                    .HasMaxLength(200)
                    .HasColumnName("TEXTSOC")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbTipPrncoUsro>(entity =>
            {
                entity.HasKey(e => e.IdTipPrncoUsro)
                    .HasName("PK_ID_TIP_PRNCO_USRO")
                    .IsClustered(false);

                entity.ToTable("TB_TIP_PRNCO_USRO");

                entity.Property(e => e.IdTipPrncoUsro).HasColumnName("ID_TIP_PRNCO_USRO");

                entity.Property(e => e.TxTipPrncoUsro)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TX_TIP_PRNCO_USRO");
            });

            modelBuilder.Entity<TbTipRfrnaVnclo>(entity =>
            {
                entity.HasKey(e => e.IdTipRfrnaVnclo)
                    .HasName("PK_TIP_RFRNA_VNCLO")
                    .IsClustered(false);

                entity.ToTable("TB_TIP_RFRNA_VNCLO");

                entity.Property(e => e.IdTipRfrnaVnclo).HasColumnName("ID_TIP_RFRNA_VNCLO");

                entity.Property(e => e.TxTipRfrnaVnclo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TX_TIP_RFRNA_VNCLO");
            });

            modelBuilder.Entity<TbTipSssao>(entity =>
            {
                entity.HasKey(e => e.IdTipSssao)
                    .HasName("PK_ID_TIP_SSSAO")
                    .IsClustered(false);

                entity.ToTable("TB_TIP_SSSAO");

                entity.Property(e => e.IdTipSssao).HasColumnName("ID_TIP_SSSAO");

                entity.Property(e => e.TxTipSssao)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TX_TIP_SSSAO");
            });

            modelBuilder.Entity<TbTipoExameOcpal>(entity =>
            {
                entity.HasKey(e => e.IdTipoExameOcpal)
                    .HasName("PK_ID_TIPO_EXAME_OCPAL")
                    .IsClustered(false);

                entity.ToTable("TB_TIPO_EXAME_OCPAL");

                entity.Property(e => e.IdTipoExameOcpal).HasColumnName("ID_TIPO_EXAME_OCPAL");

                entity.Property(e => e.CdTipoExameOcpal).HasColumnName("CD_TIPO_EXAME_OCPAL");

                entity.Property(e => e.DsTipoExameOcpal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DS_TIPO_EXAME_OCPAL");
            });

            modelBuilder.Entity<TbTipoIndorCampoMntto>(entity =>
            {
                entity.HasKey(e => e.IdTipoIndorCampoMntto)
                    .HasName("PK_ID_TIPO_INDOR_CAMPO_MNTTO")
                    .IsClustered(false);

                entity.ToTable("TB_TIPO_INDOR_CAMPO_MNTTO");

                entity.Property(e => e.IdTipoIndorCampoMntto)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TIPO_INDOR_CAMPO_MNTTO");

                entity.Property(e => e.DsTipoIndorCampoMntto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DS_TIPO_INDOR_CAMPO_MNTTO");
            });

            modelBuilder.Entity<TbTipoMdico>(entity =>
            {
                entity.HasKey(e => e.IdTipoMdico)
                    .HasName("PK_ID_TIPO_MDICO")
                    .IsClustered(false);

                entity.ToTable("TB_TIPO_MDICO");

                entity.Property(e => e.IdTipoMdico).HasColumnName("ID_TIPO_MDICO");

                entity.Property(e => e.DsTipoMdico)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("DS_TIPO_MDICO");
            });

            modelBuilder.Entity<TbTipoRstdoAso>(entity =>
            {
                entity.HasKey(e => e.IdTipoRstdoAso)
                    .HasName("PK_ID_TIPO_RSTDO_ASO")
                    .IsClustered(false);

                entity.ToTable("TB_TIPO_RSTDO_ASO");

                entity.Property(e => e.IdTipoRstdoAso).HasColumnName("ID_TIPO_RSTDO_ASO");

                entity.Property(e => e.CdTipoRstdoAso).HasColumnName("CD_TIPO_RSTDO_ASO");

                entity.Property(e => e.DsTipoRstdoAso)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DS_TIPO_RSTDO_ASO");
            });

            modelBuilder.Entity<TbTipoRstdoExame>(entity =>
            {
                entity.HasKey(e => e.IdTipoRstdoExame)
                    .HasName("PK_ID_TIPO_RSTDO_EXAME")
                    .IsClustered(false);

                entity.ToTable("TB_TIPO_RSTDO_EXAME");

                entity.Property(e => e.IdTipoRstdoExame).HasColumnName("ID_TIPO_RSTDO_EXAME");

                entity.Property(e => e.CdTipoRstdoExame).HasColumnName("CD_TIPO_RSTDO_EXAME");

                entity.Property(e => e.DsTipoRstdoExame)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DS_TIPO_RSTDO_EXAME");
            });

            modelBuilder.Entity<TbTpoRsptum>(entity =>
            {
                entity.HasKey(e => e.IdTpoRspta)
                    .HasName("PK__TB_TPO_R__5F75DF148D2E2D38");

                entity.ToTable("TB_TPO_RSPTA");

                entity.Property(e => e.IdTpoRspta).HasColumnName("ID_TPO_RSPTA");

                entity.Property(e => e.CdTpoRspta).HasColumnName("CD_TPO_RSPTA");

                entity.Property(e => e.TxTpoRspta)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TX_TPO_RSPTA");
            });

            modelBuilder.Entity<TbTrmo>(entity =>
            {
                entity.HasKey(e => e.IdTrmo);

                entity.ToTable("TB_TRMO");

                entity.Property(e => e.IdTrmo).HasColumnName("ID_TRMO");

                entity.Property(e => e.DtRspta)
                    .HasColumnType("datetime")
                    .HasColumnName("DT_RSPTA");

                entity.Property(e => e.IdRsptaFrmro).HasColumnName("ID_RSPTA_FRMRO");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.TxLgnda)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("TX_LGNDA");
            });

            modelBuilder.Entity<TbTrnsa>(entity =>
            {
                entity.HasKey(e => e.IdTrnsa)
                    .IsClustered(false);

                entity.ToTable("TB_TRNSA");

                entity.Property(e => e.IdTrnsa).HasColumnName("ID_TRNSA");

                entity.Property(e => e.DhTrnsa)
                    .HasColumnType("datetime")
                    .HasColumnName("DH_TRNSA");

                entity.Property(e => e.DsObsroTrnsa)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DS_OBSRO_TRNSA");

                entity.Property(e => e.IdAso).HasColumnName("ID_ASO");

                entity.Property(e => e.IdStcoTrnsa).HasColumnName("ID_STCO_TRNSA");
            });

            modelBuilder.Entity<TmpMedicoaso>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TMP_MEDICOASO");

                entity.Property(e => e.Crm)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CRM");

                entity.Property(e => e.Handle).HasColumnName("HANDLE");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("UF");
            });

            modelBuilder.Entity<TpSxo>(entity =>
            {
                entity.ToTable("TP_SXO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CdSxo).HasColumnName("CD_SXO");

                entity.Property(e => e.TxSxo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TX_SXO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}