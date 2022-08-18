using HyperGistPersistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HyperGistPersistence.Interfaces
{
    public interface IHyperGistUnitOfWork
    {
        IAbbreviatedLinkRepository AbbreviatedLinkRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
