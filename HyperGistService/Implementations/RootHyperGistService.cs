using HyperGistDomain.DTO.Requests;
using HyperGistDomain.DTO.Response;
using HyperGistPersistence.Interfaces;
using HyperGistService.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HyperGistService.Implementations
{
    public class RootHyperGistService : IRootHyperGistService
    {
        private IHyperGistUnitOfWork _hyperGistUnitOfWork;
        private readonly IConfiguration _configuration;

        public RootHyperGistService(IHyperGistUnitOfWork hyperGistUnitOfWork,IConfiguration configuration)
        {
            _hyperGistUnitOfWork = hyperGistUnitOfWork;
            this._configuration = configuration;
        }

        public async Task<GetShortLinkResponse> GetShortLinkHandle(GetShortLinkReq message, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _hyperGistUnitOfWork.AbbreviatedLinkRepository.AddAsync(message.FullLink,
                                                                                     _configuration.GetValue<string>("Configurations:Prefix"),
                                                                                     _configuration.GetValue<int>("Configurations:DigitNo"),
                                                                                     cancellationToken);
            }
            catch (Exception ex)
            {
                return new GetShortLinkResponse(false, "Error saving short link");
            }
        }
        public async Task<GetFullLinkResponse> GetFullLinkHandle(GetFullLinkReq message, CancellationToken cancellationToken = default)
        {
            try
            {
                return await _hyperGistUnitOfWork.AbbreviatedLinkRepository.GetFullLinkAsync(message.ShortLink, cancellationToken);
            }
            catch (Exception ex)
            {
                return new GetFullLinkResponse(false, "Error Getting full link");
            }
        }

      
    }
}
