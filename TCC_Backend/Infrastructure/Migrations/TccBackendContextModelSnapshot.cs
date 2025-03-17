﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCC_Backend.Infrastructure.Context.AppDbContext;

#nullable disable

namespace TCC_Backend.Infrastructure.Migrations
{
    [DbContext(typeof(TccBackendContext))]
    partial class TccBackendContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TCC_Backend.Domain.Models.Adms.Adm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("adm", (string)null);
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Auditorias.Auditoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Acao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ChavePrimaria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Entidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Propriedade")
                        .HasColumnType("longtext");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ValorAntigo")
                        .HasColumnType("longtext");

                    b.Property<string>("ValorNovo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Auditorias");
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Avaliacoes.Avaliacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataAvalicao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<Guid>("IdServico")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Nota")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdServico");

                    b.ToTable("avalicao", (string)null);
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Historicos.Historico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<DateTime?>("DataReferencia")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<Guid>("IdServico")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("MediaCategoria1")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MediaCategoria2")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MediaCategoria3")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MediaCategoria4")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MediaCategoria5")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("NumeroDeAvaliacoes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdServico");

                    b.ToTable("historico", (string)null);
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.LastExecutions.LastExecution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<DateTime?>("LastExecutionDate")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("last_execution", (string)null);
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Reports.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ErrorCategory")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReportType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SuggestionCategory")
                        .HasMaxLength(22)
                        .HasColumnType("varchar(22)");

                    b.Property<bool>("WantsContact")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("report", (string)null);
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.SecaoEleitorais.SecaoEleitoral", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cidade")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("LocalVotacao")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("ZonaEleitoral")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.HasKey("Id");

                    b.ToTable("secao_eleitoral", (string)null);
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Servicos.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("NumeroDeAvalicoes")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("servico", (string)null);
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.UsuarioServicosAvaliacao.UsuarioServicoAvaliacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<DateTime>("DataUltimaAvaliacao")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ServicoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ServicoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("usuario_servicos_avaliacoes", (string)null);
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Usuarios.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecaoEleitoral")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("TituloEleitor")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("ZonaEleitoral")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Avaliacoes.Avaliacao", b =>
                {
                    b.HasOne("TCC_Backend.Domain.Models.Servicos.Servico", "Servico")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("IdServico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Historicos.Historico", b =>
                {
                    b.HasOne("TCC_Backend.Domain.Models.Servicos.Servico", "Servico")
                        .WithMany("Historicos")
                        .HasForeignKey("IdServico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.UsuarioServicosAvaliacao.UsuarioServicoAvaliacao", b =>
                {
                    b.HasOne("TCC_Backend.Domain.Models.Servicos.Servico", "Servico")
                        .WithMany("UsuarioServicoAvaliacoes")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TCC_Backend.Domain.Models.Usuarios.Usuario", "Usuario")
                        .WithMany("UsuarioServicoAvaliacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Servico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Servicos.Servico", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Historicos");

                    b.Navigation("UsuarioServicoAvaliacoes");
                });

            modelBuilder.Entity("TCC_Backend.Domain.Models.Usuarios.Usuario", b =>
                {
                    b.Navigation("UsuarioServicoAvaliacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
