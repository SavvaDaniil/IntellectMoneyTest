using IntellectMoneyTest.Data;
using IntellectMoneyTest.Models;
using System.Collections.Generic;

namespace IntellectMoneyTest.Services
{
    public class UserLiteService
    {
        private ApplicationDbContext _dbc;

        public UserLiteService(ApplicationDbContext dbc)
        {
            _dbc = dbc;
        }

        public List<UserLite> listAll()
        {
            //откуда-то из каких-то витрин подгружается модели для рассылки
            List < UserLite > mockUserLites = new List<UserLite>();

            return mockUserLites;
        }
    }
}
