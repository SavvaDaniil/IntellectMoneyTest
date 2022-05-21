using IntellectMoneyTest.Abstracts;
using System;

namespace IntellectMoneyTest.States.Newsletter
{
    public class NewsletterInActiveState : NewsletterStateAbstract
    {
        public NewsletterInActiveState(int id_of_last_newsletter, DateTime dateLastStart)
        {
            this.id_of_last_newsletter = id_of_last_newsletter;
            this.dateLastStart = dateLastStart;
        }
    }
}
