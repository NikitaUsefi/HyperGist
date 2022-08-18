using HyperGistDomain;
using HyperGistDomain.Entity;
using HyperGistPersistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperGistPersistence
{
    public class HyperGistDbContext:DbContext
    {
        public HyperGistDbContext(DbContextOptions<HyperGistDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AbbreviatedLinkConfigurations).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AbbreviatedLinkCounterConfigurations).Assembly);
        }
        public void AuditChanges()
        {
            List<EntityEntry> entities = ChangeTracker.Entries().Where(x => {
                return x.State == EntityState.Added || x.State == EntityState.Modified;
              }).ToList();
            entities.ForEach(x=> {
                if (x.Entity.GetType().IsSubclassOf(typeof(BaseEntity)))
                {
                    ((BaseEntity)x.Entity).Modified = DateTime.Now;
                }
            });
        }
        public override int SaveChanges()
        {
            AuditChanges();
            return base.SaveChanges();
        }
        public DbSet<AbbreviatedLink> AbbreviationLinks { get; set; }
        public DbSet<AbbreviatedLinkCounter> AbbreviationLinkCounters { get; set; }
    }
}
