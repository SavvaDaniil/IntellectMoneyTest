using IntellectMoneyTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntellectMoneyTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserMail> UserMails { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
    }
}
