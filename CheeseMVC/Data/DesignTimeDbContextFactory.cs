using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CheeseDbContext>
    {
        public CheeseDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CheeseDbContext>();

            var connectionString = configuration.GetConnectionString("CheeseDbContext");

            builder.UseSqlServer(connectionString);

            return new CheeseDbContext(builder.Options);
        }
    }
}
