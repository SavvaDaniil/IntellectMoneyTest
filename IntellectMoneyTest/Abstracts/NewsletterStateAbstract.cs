using System;

namespace IntellectMoneyTest.Abstracts
{
    public abstract class NewsletterStateAbstract
    {
        public int id_of_last_newsletter { get; set; }
        public DateTime? dateLastStart { get; set; }
    }
}
