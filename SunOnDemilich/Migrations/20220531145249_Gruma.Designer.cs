﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SunOnDemilich.Context;

#nullable disable

namespace SunOnDemilich.Migrations
{
    [DbContext(typeof(ContextoInicial))]
    [Migration("20220531145249_Gruma")]
    partial class Gruma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("SunOnDemilich.Entities.EfmigrationsHistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__EFMigrationsHistory", (string)null);
                });

            modelBuilder.Entity("SunOnDemilich.Entities.TbBbEp", b =>
                {
                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("CPF");

                    b.Property<DateOnly>("Cmpt")
                        .HasColumnType("date")
                        .HasColumnName("CMPT");

                    b.Property<int>("CodComiss")
                        .HasColumnType("int(11)")
                        .HasColumnName("COD_COMISS");

                    b.Property<string>("Comissao")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("COMISSAO");

                    b.Property<int>("Competencia")
                        .HasColumnType("int(11)")
                        .HasColumnName("COMPETENCIA");

                    b.Property<DateOnly>("DataPosse")
                        .HasColumnType("date")
                        .HasColumnName("DATA_POSSE");

                    b.Property<string>("Dependencia")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("DEPENDENCIA");

                    b.Property<string>("Flag")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("FLAG");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("enum('Masculino','Feminino')")
                        .HasColumnName("GENERO");

                    b.Property<int>("MatriculaFuncional")
                        .HasColumnType("int(11)")
                        .HasColumnName("MATRICULA_FUNCIONAL");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("MUNICIPIO");

                    b.Property<DateOnly>("Nascimento")
                        .HasColumnType("date")
                        .HasColumnName("NASCIMENTO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("NOME");

                    b.Property<int>("Prefixo")
                        .HasColumnType("int(11)")
                        .HasColumnName("PREFIXO");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("enum('AC','AL','AM','AP','BA','CE','DF','ES','GO','MA','MG','MS','MT','PA','PB','PE','PI','PR','RJ','RN','RO','RR','RS','SC','SE','SP','TO')")
                        .HasColumnName("UF");

                    b.HasKey("Cpf")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Cpf" }, "TB_BB_EPS_22_CPF_uindex")
                        .IsUnique();

                    b.HasIndex(new[] { "MatriculaFuncional" }, "TB_BB_EPS_22_MATRICULA_FUNCIONAL_uindex")
                        .IsUnique();

                    b.ToTable("TB_BB_EPS", (string)null);
                });

            modelBuilder.Entity("SunOnDemilich.Entities.TbVgkg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ID");

                    b.Property<string>("Dttme")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("DTTME")
                        .HasComment("Get the image's publication date and time.");

                    b.Property<string>("Srce")
                        .HasMaxLength(1052)
                        .HasColumnType("varchar(1052)")
                        .HasColumnName("SRCE")
                        .HasComment("Gets the source URI of the image.");

                    b.Property<string>("Srcfd")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("SRCFD")
                        .HasComment("Gets the source URI of the first article that used the image.");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "TB_VGKG_ID_uindex")
                        .IsUnique();

                    b.ToTable("TB_VGKG", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
