using IntellectMoneyTest.Abstracts;
using System;

namespace IntellectMoneyTest.States.Newsletter
{
    public class NewsletterStopState : NewsletterStateAbstract
    {
        public DateTime? dateStopStart { get; set; }

        public NewsletterStopState()
        {
        }

        public NewsletterStopState(int id_of_last_newsletter, DateTime? dateLastStart, DateTime? dateStopStart)
        {
            this.id_of_last_newsletter = id_of_last_newsletter;
            this.dateLastStart = dateLastStart;
            this.dateStopStart = dateStopStart;
        }
    }
}
