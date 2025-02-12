using Microsoft.EntityFrameworkCore;
using TCC_Backend.Domain.Models;
using TCC_Backend.Domain.Models.Auditorias;
using TCC_Backend.Domain.Models.Avaliacoes;
using TCC_Backend.Domain.Models.Historicos;
using TCC_Backend.Domain.Models.Servicos;
using TCC_Backend.Domain.Models.Usuarios;
using TCC_Backend.Domain.Models.UsuarioServicosAvaliacao;
using TCC_Backend.Infrastructure.Context.Configurations.AvaliacoesEntityConfigurations;
using TCC_Backend.Infrastructure.Context.Configurations.BaseEntityConfigurations;
using TCC_Backend.Infrastructure.Context.Configurations.HistoricoEntityConfigurations;
using TCC_Backend.Infrastructure.Context.Configurations.ServicoEntityConfigurations;
using TCC_Backend.Infrastructure.Context.Configurations.UsuarioEntityConfigurations;
using TCC_Backend.Infrastructure.Context.Configurations.UsuarioServicosAvaliacao;

namespace TCC_Backend.Infrastructure.Context.AppDbContext
{
    public class TccBackendContext : DbContext
    {
        public TccBackendContext(DbContextOptions options) : base(options) { }

        public DbSet<Auditoria> Auditorias { get; set; }

        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public DbSet<BaseEntity> BaseEntitys { get; set; }

        public DbSet<Historico> Historicos { get; set; }

        public DbSet<Servico> Servicos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<UsuarioServicoAvaliacao> UsuarioServicoAvaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AvalicacaoEnityConfiguration());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HistoricoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ServicoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioServicoAvaliacaoEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var auditorias = new List<Auditoria>();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.AtualizarDataDeEstados(entry.State);
                var id = entry.OriginalValues["Id"]!.ToString();
                var usuario = "Sistema";

                switch (entry.State)
                {
                    case EntityState.Added:

                        var entidadeAdded = entry.Entity.GetType().Name;

                        auditorias.Add(new Auditoria
                        {
                            Entidade = entidadeAdded,
                            ChavePrimaria = id!,
                            Acao = "INSERT",
                            Usuario = usuario,
                        });
                        break;

                    case EntityState.Modified:

                        entry.Entity.AtualizarDataDeEstados(entry.State);

                        var entidadeModified = entry.Entity.GetType().Name;

                        foreach (var prop in entry.OriginalValues.Properties)
                        {
                            var original = entry.OriginalValues[prop]?.ToString();
                            var atual = entry.CurrentValues[prop]?.ToString();

                            if (original != atual) // Apenas se houver mudança
                            {
                                auditorias.Add(new Auditoria
                                {
                                    Entidade = entidadeModified,
                                    ChavePrimaria = id!,
                                    Acao = "UPDATE",
                                    Propriedade = prop.Name,
                                    ValorAntigo = original,
                                    ValorNovo = atual,
                                    Usuario = usuario,
                                });
                            }
                        }
                        break;

                    case EntityState.Deleted:

                        var entidadeDeleted = entry.Entity.GetType().Name;
  
                        auditorias.Add(new Auditoria
                        {
                            Entidade = entidadeDeleted,
                            ChavePrimaria = id!,
                            Acao = "DELETE",
                            Usuario = usuario,
                        });
                        break;
                }
            }

            if (auditorias.Any())
            {
                this.Set<Auditoria>().AddRange(auditorias);
            }

            return base.SaveChanges();
        }

    }
}
