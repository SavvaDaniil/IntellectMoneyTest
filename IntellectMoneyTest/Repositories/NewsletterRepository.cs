using IntellectMoneyTest.Data;
using IntellectMoneyTest.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IntellectMoneyTest.Repositories
{
    public class NewsletterRepository
    {
        private ApplicationDbContext _dbc;

        public NewsletterRepository(ApplicationDbContext dbc)
        {
            _dbc = dbc;
        }

        public async Task<Newsletter> findById(int id)
        {
            return await _dbc.Newsletters.FirstOrDefaultAsync(p => p.id == id);
        }
    }
}
