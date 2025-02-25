﻿using Microsoft.EntityFrameworkCore;
using TCC_Backend.Domain.Models;
using TCC_Backend.Domain.Models.Auditorias;
using TCC_Backend.Domain.Models.Avaliacoes;
using TCC_Backend.Domain.Models.Historicos;
using TCC_Backend.Domain.Models.Servicos;
using TCC_Backend.Domain.Models.Usuarios;
using TCC_Backend.Domain.Models.UsuarioServicosAvaliacao;
using TCC_Backend.Infrastructure.Context.Configurations.AvaliacoesEntityConfigurations;
using TCC_Backend.Infrastructure.Context.Configurations.HistoricoEntityConfigurations;
using TCC_Backend.Infrastructure.Context.Configurations.ServicoEntityConfigurations;
using TCC_Backend.Infrastructure.Context.Configurations.UsuarioEntityConfigurations;
using TCC_Backend.Infrastructure.Context.Configurations.UsuarioServicosAvaliacao;

namespace TCC_Backend.Infrastructure.Context.AppDbContext
{
    public class TccBackendContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Auditoria> Auditorias { get; set; }

        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public DbSet<Historico> Historicos { get; set; }

        public DbSet<Servico> Servicos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<UsuarioServicoAvaliacao> UsuarioServicoAvaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AvalicacaoEnityConfiguration());
            modelBuilder.ApplyConfiguration(new HistoricoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ServicoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioServicoAvaliacaoEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var auditorias = new List<Auditoria>();

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.AtualizarDataDeEstados(entry.State);
                var id = entry.OriginalValues["Id"]!.ToString();
                var usuario = "Sistema"; // Ainda precisa ser implementado corretamente.

                switch (entry.State)
                {
                    case EntityState.Added:
                        auditorias.Add(new Auditoria
                        {
                            Entidade = entry.Entity.GetType().Name,
                            ChavePrimaria = id!,
                            Acao = "INSERT",
                            Usuario = usuario,
                        });
                        break;

                    case EntityState.Modified:
                        foreach (var prop in entry.OriginalValues.Properties)
                        {
                            var original = entry.OriginalValues[prop]?.ToString();
                            var atual = entry.CurrentValues[prop]?.ToString();

                            if (original != atual)
                            {
                                auditorias.Add(new Auditoria
                                {
                                    Entidade = entry.Entity.GetType().Name,
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
                        auditorias.Add(new Auditoria
                        {
                            Entidade = entry.Entity.GetType().Name,
                            ChavePrimaria = id!,
                            Acao = "DELETE",
                            Usuario = usuario,
                        });
                        break;
                }
            }

            if (auditorias.Count == 0)
            {
                await this.Set<Auditoria>().AddRangeAsync(auditorias, cancellationToken);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
