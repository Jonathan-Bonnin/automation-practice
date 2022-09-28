using NUnit.Framework;

namespace AutomationPractice.Pages.ContactUs
{
    internal partial class ContactUsPage
    {
        internal void AssertSuccessMessageShown()
        {
            Assert.AreEqual(_driver.FindElement(_alertSuccessMessageBy).Text, "Your message has been successfully sent to our team.");
        }

        internal void AssertInvalidEmailMessageShown()
        {
            Assert.AreEqual(_driver.FindElement(_altertDangerMessageBy).Text, "Invalid email address.");
        }
    }
}
