using IntellectMoneyTest.Abstracts;
using IntellectMoneyTest.Components;
using IntellectMoneyTest.Data;
using IntellectMoneyTest.Entities;
using IntellectMoneyTest.Factories.Data;
using IntellectMoneyTest.Repositories;
using IntellectMoneyTest.States.Newsletter;
using IntellectMoneyTest.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntellectMoneyTest.Facades
{
    public class NewsletterFacade
    {
        private ApplicationDbContext _dbc;
        private IServiceScopeFactory _serviceScopeFactory;

        private static NewsletterStateAbstract _newsletterState;

        public NewsletterFacade(ApplicationDbContext dbc, IServiceScopeFactory serviceScopeFactory)
        {
            _dbc = dbc;
            _serviceScopeFactory = serviceScopeFactory;
            if (_newsletterState == null) _newsletterState = new NewsletterStopState();
        }

        public async Task<JsonAnswerStatus> launchById(int id_of_newsletter)
        {
            if (_newsletterState is NewsletterInActiveState)
            {
                StringBuilder message = new StringBuilder();
                if (_newsletterState.id_of_last_newsletter != 0)
                {
                    message = new StringBuilder("Now running Newsletter " + _newsletterState.id_of_last_newsletter);
                    if (_newsletterState.dateLastStart.HasValue) 
                        message.Append(" launched " + _newsletterState.dateLastStart.Value.ToString("dd.MM.yyyy HH:mm:ss"));
                }
                return new JsonAnswerStatus("error", "busy", message.ToString());
            }

            NewsletterRepository newsletterRepository = new NewsletterRepository(_dbc);
            Newsletter newsletter = await newsletterRepository.findById(id_of_newsletter);
            if (newsletter == null) return new JsonAnswerStatus("error", "not_found");
            if (newsletter.messageText == null) return new JsonAnswerStatus("error", "no_message_in_newsletter");

            UserMailFacade userMailFacade = new UserMailFacade(_dbc);
            List<UserMail> userMails = await userMailFacade.listAllNotSendedByNewsletter(newsletter);
            if (userMails == null) return new JsonAnswerStatus("success", null, "no_users");

            this.startNewsletter(newsletter);

            int lengthOfUserMails = userMails.Count;
            int schetchikOfUserMail = 0;

            foreach (UserMail userMail in userMails)
            {
                schetchikOfUserMail++;
                if (userMail.username == null) await userMailFacade.setErrorSending(userMail);

                var threadSendingMailToUser = new Thread(async () =>
                {
                    await sendMailToUser(userMail, newsletter, (schetchikOfUserMail == lengthOfUserMails));
                });
            }

            return new JsonAnswerStatus("success");
        }


        private void startNewsletter(Newsletter newsletter) => _newsletterState = new NewsletterInActiveState(newsletter.id, DateTime.Now);
        private void stopNewsletter(Newsletter newsletter)
        {
            DateTime? dateLastStart = (_newsletterState is NewsletterInActiveState ? _newsletterState.dateLastStart : null);
            _newsletterState = new NewsletterStopState(newsletter.id, dateLastStart, DateTime.Now);
        }


        private async Task sendMailToUser(UserMail userMail, Newsletter newsletter, bool isLast = false)
        {
            ApplicationDbContextFactory applicationDbContextFactory = new ApplicationDbContextFactory();
            using (var Dbcontext = applicationDbContextFactory.create())
            {
                UserMailFacade userMailFacade = new UserMailFacade(Dbcontext);
                MailSenderComponent mailSenderComponent = new MailSenderComponent();
                if (mailSenderComponent.sendMailToUsername(userMail.username, newsletter.subject, newsletter.messageText))
                {
                    await userMailFacade.setSuccessSendedMail(userMail);
                }
                else
                {
                    await userMailFacade.setErrorSending(userMail);
                }

                if (isLast) stopNewsletter(newsletter);
            }
        }
    }
}
