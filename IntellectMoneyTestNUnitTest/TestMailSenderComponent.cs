using IntellectMoneyTest.Components;
using NUnit.Framework;

namespace IntellectMoneyTestNUnitTest
{
    public class TestMailSenderComponent
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSendMail()
        {
            const string usernameForTest = "XXXXXXXXXX";
            MailSenderComponent mailSenderComponent = new MailSenderComponent();

            Assert.IsTrue(mailSenderComponent.sendMailToUsername(usernameForTest, "Test subject", "Test message text"));
        }
    }
}
