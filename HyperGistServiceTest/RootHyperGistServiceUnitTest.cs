using HyperGistDomain.DTO.Requests;
using HyperGistDomain.DTO.Response;
using HyperGistPersistence;
using HyperGistPersistence.Implimentations;
using HyperGistPersistence.Interfaces;
using HyperGistService.Implementations;
using HyperGistService.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HyperGistServiceTest
{
    public class RootHyperGistServiceUnitTest
    {
        private IConfiguration _configuration;
        public RootHyperGistServiceUnitTest()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
        [Fact]
        public async Task GetShortLinkUnitTest()
        {
            using (HyperGistDbContext dbContext = new HyperGistDbContextFactory().Create())
            {
                IHyperGistUnitOfWork hyperGistUnitOfWork = new HyperGistUnitOfWork(dbContext, _configuration);
                IRootHyperGistService rootHyperGistService = new RootHyperGistService(hyperGistUnitOfWork, _configuration);
                GetShortLinkResponse getShortLinkResponse = await rootHyperGistService.GetShortLinkHandle(new GetShortLinkReq("https://github.com/"));
                Assert.True(getShortLinkResponse.IsSuccessful);
            }
        }
        [Fact]
        public async Task GetFullLinkUnitTest()
        {
            using (HyperGistDbContext dbContext = new HyperGistDbContextFactory().Create())
            {
                IHyperGistUnitOfWork hyperGistUnitOfWork = new HyperGistUnitOfWork(dbContext, _configuration);
                IRootHyperGistService rootHyperGistService = new RootHyperGistService(hyperGistUnitOfWork, _configuration);
                GetShortLinkResponse getShortLinkResponse = await rootHyperGistService.GetShortLinkHandle(new GetShortLinkReq("https://github.com/"));
                GetFullLinkResponse getFullLinkResponse = await rootHyperGistService.GetFullLinkHandle(new GetFullLinkReq(getShortLinkResponse.ShortLink));
                Assert.True(getFullLinkResponse.IsSuccessful);
            }
        }
    }
}
