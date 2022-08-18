using HyperGistPersistence.Interfaces;
using HyperGistPersistence.Repositories.Implimentations;
using HyperGistPersistence.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HyperGistPersistence.Implimentations
{
    public class HyperGistUnitOfWork : IHyperGistUnitOfWork
    {
        private readonly HyperGistDbContext _hyperGistDbContext;
        private readonly IConfiguration _configuration;

        public HyperGistUnitOfWork(HyperGistDbContext hyperGistDbContext, IConfiguration configuration)
        {
            _hyperGistDbContext = hyperGistDbContext;
            _configuration = configuration;
            AbbreviatedLinkRepository = new AbbreviatedLinkRepository(_hyperGistDbContext, _configuration);
        }
        public IAbbreviatedLinkRepository AbbreviatedLinkRepository { get; }

        public async Task SaveChangesAsync(CancellationToken cancellationToken=default)
        {
            if (_hyperGistDbContext.ChangeTracker.HasChanges())
            {
                await _hyperGistDbContext.SaveChangesAsync();
            }
        }
    }
}
