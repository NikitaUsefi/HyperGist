using HyperGistDomain;
using HyperGistDomain.DTO.Response;
using HyperGistPersistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace HyperGistPersistence.Repositories.Implimentations
{
    public class AbbreviatedLinkRepository : IAbbreviatedLinkRepository
    {
        private  HyperGistDbContext _hyperGistDbContext;
        private readonly IConfiguration _configuration;

        public AbbreviatedLinkRepository(HyperGistDbContext hyperGistDbContext,IConfiguration configuration)
        {
            _hyperGistDbContext = hyperGistDbContext;
            _configuration = configuration;
        }
        public async Task<GetShortLinkResponse> AddAsync(string fullLink, string prefix ,int digitNo, CancellationToken cancellationToken=default)
        {
            try
            {
                fullLink = fullLink.Trim().ToLower();
                //check if we have the same full link in the data base return the same shortlink
                 var link=_hyperGistDbContext.AbbreviationLinks.Where(x => x.FullLink.Equals(fullLink)
                                                                    &&  prefix.Equals(x.Prefix)
                                                                    && x.Active
                                                                    && !x.Deleted).FirstOrDefault();
                if (link != null)
                {
                    return new GetShortLinkResponse(link.ShortLink, true, "Successfully saved shortLink");
                }
                //if the full link is new, then save it in DB and increase the counter
                AbbreviatedLinkCounter abbreviatedLinkCounter=  _hyperGistDbContext.AbbreviationLinkCounters
                                                                                   .Where(x=> prefix.Equals(x.Prefix)
                                                                                             && x.Active
                                                                                             &&! x.Deleted)
                                                                                   .FirstOrDefault();
                if(abbreviatedLinkCounter is null)
                {
                    abbreviatedLinkCounter = new AbbreviatedLinkCounter(prefix,
                                                                        HyperGistCommon.CounterHelper.GetMinimumSequence(digitNo));
                    await _hyperGistDbContext.AddAsync(abbreviatedLinkCounter, cancellationToken);
                }
                else{
                    abbreviatedLinkCounter.LastCount=HyperGistCommon.CounterHelper.IncrementSequence(abbreviatedLinkCounter.LastCount);
                }
                var abbreviatedLink = new AbbreviatedLink(abbreviatedLinkCounter.Prefix, abbreviatedLinkCounter.LastCount, fullLink);
                await _hyperGistDbContext.AbbreviationLinks.AddAsync(abbreviatedLink, cancellationToken);
                await _hyperGistDbContext.SaveChangesAsync(cancellationToken);
                return new GetShortLinkResponse(abbreviatedLink.ShortLink, true, "Successfully saved shortLink");

            }
            catch (Exception ex)
            {
                return new GetShortLinkResponse(false, $"Error inserting short link: {ex.ToString()}");
            }
        }
        public async Task<GetFullLinkResponse> GetFullLinkAsync(string shortLink, CancellationToken cancellationToken = default)
        {
            try
            {
                AbbreviatedLink abbreviatedLink =await _hyperGistDbContext.AbbreviationLinks
                                                                     .Where(x => x.ShortLink.Equals(shortLink)
                                                                                 && x.Active
                                                                                 && !x.Deleted)
                                                                     .FirstOrDefaultAsync(cancellationToken);
                if (abbreviatedLink == null)
                {
                    return new GetFullLinkResponse(false, "the short link is not valid");
                }
                return new GetFullLinkResponse(abbreviatedLink.FullLink, true, "successfully getting the fullLink");

            }
            catch (Exception ex)
            {
                return new GetFullLinkResponse(false, $"Error getting fullLink: {ex.ToString()}");
            }
        }
    }
}
