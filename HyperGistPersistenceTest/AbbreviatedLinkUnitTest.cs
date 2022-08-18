using HyperGistDomain.DTO.Response;
using HyperGistPersistence;
using HyperGistPersistence.Implimentations;
using HyperGistPersistence.Interfaces;
using HyperGistPersistence.Repositories.Implimentations;
using HyperGistPersistence.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HyperGistPersistenceTest
{
    public class AbbreviatedLinkUnitTest
    {
        private IConfiguration _configuration;
        public AbbreviatedLinkUnitTest()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
        [Fact]
        public async Task AddTest()
        {
            using(HyperGistDbContext dbContext=new HyperGistDbContextFactory().Create())
            {
                IHyperGistUnitOfWork hyperGistUnitOfWork = new HyperGistUnitOfWork(dbContext, _configuration);
                GetShortLinkResponse getShortLinkResponse = await hyperGistUnitOfWork.AbbreviatedLinkRepository.AddAsync("https://github.com/",
                                                                                     _configuration.GetValue<string>("Configurations:Prefix"),
                                                                                     _configuration.GetValue<int>("Configurations:DigitNo"));
                Assert.True(getShortLinkResponse.IsSuccessful);
            }
        }
        [Fact]
        public async Task GetFullLinkTest()
        {
            using (HyperGistDbContext dbContext = new HyperGistDbContextFactory().Create())
            {
                IAbbreviatedLinkRepository abbreviatedLinkRepository = new AbbreviatedLinkRepository(dbContext, _configuration);
                GetShortLinkResponse getShortLinkResponse = await abbreviatedLinkRepository.AddAsync("https://github.com/",
                                                                                     _configuration.GetValue<string>("Configurations:Prefix"),
                                                                                     _configuration.GetValue<int>("Configurations:DigitNo"));
                GetFullLinkResponse getFullLinkResponse = await abbreviatedLinkRepository.GetFullLinkAsync(getShortLinkResponse.ShortLink);
                Assert.True(getFullLinkResponse.IsSuccessful);
            }
        }
    }
}
