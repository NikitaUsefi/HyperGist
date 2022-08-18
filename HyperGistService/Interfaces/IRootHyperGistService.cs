using HyperGistDomain.DTO.Requests;
using HyperGistDomain.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HyperGistService.Interfaces
{
    public interface IRootHyperGistService
    {
        Task<GetShortLinkResponse> GetShortLinkHandle(GetShortLinkReq message, CancellationToken cancellationToken=default);
        Task<GetFullLinkResponse> GetFullLinkHandle(GetFullLinkReq message, CancellationToken cancellationToken = default);
    }
}
