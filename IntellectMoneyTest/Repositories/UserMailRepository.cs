using IntellectMoneyTest.Data;
using IntellectMoneyTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntellectMoneyTest.Repositories
{
    public class UserMailRepository
    {

        private ApplicationDbContext _dbc;

        public UserMailRepository(ApplicationDbContext dbc)
        {
            _dbc = dbc;
        }

        public async Task<UserMail> findById(int id)
        {
            return await _dbc.UserMails.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<UserMail> findByIdOfUserAndNewsletter(int id_of_user, Newsletter newsletter)
        {
            return await _dbc.UserMails
                .OrderByDescending(p => p.id)
                .FirstOrDefaultAsync(p => p.id_of_user == id_of_user && p.newsletter == newsletter);
        }
        public async Task<bool> isAnyByIdOfUserAndNewsletter(int id_of_user, Newsletter newsletter)
        {
            return await _dbc.UserMails
                .OrderByDescending(p => p.id)
                .AnyAsync(p => p.id_of_user == id_of_user && p.newsletter == newsletter);
        }

        public async Task<List<UserMail>> listAll()
        {
            return await _dbc.UserMails.OrderByDescending(p => p.id).ToListAsync();
        }


        public async Task<UserMail> add(int id, string username, string name)
        {
            UserMail userMail = new UserMail();
            userMail.username = username;
            userMail.name = name;

            userMail.dateOfAdd = DateTime.Now;


            await _dbc.UserMails.AddAsync(userMail);
            await _dbc.SaveChangesAsync();

            return userMail;
        }

        public async Task<List<UserMail>> listAllNotSendedByNewsletter(Newsletter newsletter)
        {
            return await _dbc.UserMails
                .Where(p => p.isSended == 0 && p.active == 1 && p.mailError == 0 && p.newsletter == newsletter)
                .OrderBy(p => p.dateOfAdd)
                .ToListAsync();
        }

        public async Task<bool> delete(int id)
        {
            UserMail userMail = await findById(id);
            if (userMail == null) return false;
            _dbc.UserMails.Remove(userMail);
            await _dbc.SaveChangesAsync();
            return true;
        }

        public async Task<bool> delete(UserMail userMail)
        {
            _dbc.UserMails.Remove(userMail);
            await _dbc.SaveChangesAsync();
            return true;
        }

        public async Task setErrorSending(UserMail userMail)
        {
            userMail.mailError = 1;
            userMail.dateOfLastTrySendMail = DateTime.Now;
            await _dbc.SaveChangesAsync();
        }
        public async Task setSuccessSendedMail(UserMail userMail)
        {
            userMail.isSended = 1;
            userMail.mailError = 0;
            userMail.dateOfLastTrySendMail = DateTime.Now;
            userMail.dateOfSendMail = DateTime.Now;

            await _dbc.SaveChangesAsync();
        }
    }
}
