using IntellectMoneyTest.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace IntellectMoneyTest.Factories.Data
{
    public class ApplicationDbContextFactory
    {
        private string _connectionString = "Server=XXXXXXXXXXXXXX;port=3306;Database=XXXXXXXXXXXXXX;User ID=XXXXXXXXXXXXXX;Password=XXXXXXXXXXXXXX;Initial Catalog = XXXXXXXXXXXXXX;";

        public ApplicationDbContext create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString))
            .Options;

            return new ApplicationDbContext(options);
        }
    }
}
