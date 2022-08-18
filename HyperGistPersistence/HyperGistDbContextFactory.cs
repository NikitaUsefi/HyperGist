using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistPersistence
{
    public class HyperGistDbContextFactory : IDesignTimeDbContextFactory<HyperGistDbContext>
    {
        public HyperGistDbContext Create()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var basePath = AppContext.BaseDirectory;
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings{environmentName}.json", true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            var connectionString = config.GetConnectionString("HyperGistConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string not found");
            }
            var optionsBuilder = new DbContextOptionsBuilder<HyperGistDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var options = optionsBuilder.Options;
            return new HyperGistDbContext(options);
        }
        public HyperGistDbContext CreateDbContext(string[] args)
        {
            return Create();
        }
    }
}
