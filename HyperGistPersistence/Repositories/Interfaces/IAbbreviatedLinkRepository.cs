using HyperGistDomain;
using HyperGistDomain.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HyperGistPersistence.Repositories.Interfaces
{
    public interface IAbbreviatedLinkRepository
    {
        Task<GetShortLinkResponse> AddAsync(string fullLink, string prefix, int digitNo, CancellationToken cancellationToken = default);
        Task<GetFullLinkResponse> GetFullLinkAsync(string shortLink, CancellationToken cancellationToken = default);

    }
}
