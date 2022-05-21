using IntellectMoneyTest.Data;
using IntellectMoneyTest.Entities;
using IntellectMoneyTest.Models;
using IntellectMoneyTest.Repositories;
using IntellectMoneyTest.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntellectMoneyTest.Facades
{
    public class UserMailFacade
    {
        private ApplicationDbContext _dbc;

        public UserMailFacade(ApplicationDbContext dbc)
        {
            _dbc = dbc;
        }

        public async Task<List<UserMail>> listAllNotSendedByNewsletter(Newsletter newsletter)
        {
            UserMailRepository userMailRepository = new UserMailRepository(_dbc);
            List<UserLite> userLites = this.listAllNewForNewsletter();

            foreach (UserLite userLite in userLites)
            {
                if (await userMailRepository.isAnyByIdOfUserAndNewsletter(userLite.id, newsletter)) continue;

                await userMailRepository.add(userLite.id, userLite.username, userLite.name);
            }

            List<UserMail> userMails = await userMailRepository.listAllNotSendedByNewsletter(newsletter);
            return userMails;
        }
        
        private List<UserLite> listAllNewForNewsletter()
        {
            UserLiteService userLiteService = new UserLiteService(_dbc);
            List<UserLite> userLites = userLiteService.listAll();
            return userLites;
        }

        public async Task setErrorSending(UserMail userMail)
        {
            UserMailRepository userMailRepository = new UserMailRepository(_dbc);
            await userMailRepository.setErrorSending(userMail);
        }

        public async Task setSuccessSendedMail(UserMail userMail)
        {
            UserMailRepository userMailRepository = new UserMailRepository(_dbc);
            await userMailRepository.setSuccessSendedMail(userMail);
        }
    }
}
