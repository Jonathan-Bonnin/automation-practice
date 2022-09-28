using AutomationPractice.Pages.ContactUs;
using NUnit.Framework;

namespace AutomationPractice.Tests
{
    internal class ContactUsTest : TestBase
    {
        [Test]
        public void SubmitValidForm()
        {
            var contactUsForm = ContactUsForm.getValidForm();

            var page = new ContactUsPage(_driver);
            page.FillInForm(contactUsForm);
            page.SubmitForm();

            page.AssertSuccessMessageShown();
        }

        [Test]
        public void InvalidEmail()
        {
            var contactUsForm = ContactUsForm.getValidForm();
            contactUsForm.Email = "Invalid Email";

            var page = new ContactUsPage(_driver);
            page.FillInForm(contactUsForm);
            page.SubmitForm();

            page.AssertInvalidEmailMessageShown();
        }
    }
}
