using AutomationPractice.Pages.SignIn;
using NUnit.Framework;
using System;
using System.Linq;

namespace AutomationPractice.Tests
{
    internal class SignInTest : TestBase
    {
        private string _email;
        private string _password;
        private string _firstName;
        private string _lastName;
        private SignInPage _page;

        [Test, Order(0)]
        public void AccountAlreadyExists()
        {
            var page = new SignInPage(_driver);            
            page.SubmitCreateEmail("test@test.com");
            page.WaitForCreateAccountErrorMessage();
            page.AssertAccountAlreadyExists();
        }

        [Test, Order(1)]
        public void NewEmailRedirectsToSignUpFormWithSameEmail()
        {
            _page = new SignInPage(_driver);
            _email = GenerateRandomEmail();
            _page.SubmitCreateEmail(_email);
            _page.WaitUntilUrlChanges();
            _page.AssertRedirectedToAccountCreation();
            _page.WaitUntilEmailIsPrefilled();
            _page.AssertEmailIsAlreadyFilled(_email);
        }

        [Test, Order(2)]
        public void SubmitValidForm()
        {
            var validForm = SignInForm.GetValidForm();
            _password = validForm.Password;
            _firstName = validForm.FirstName;
            _lastName = validForm.LastName;
            _page.FillInForm(validForm);
            _page.SubmitForm();
            _page.AssertUserIsLoggedIn(validForm.FirstName, validForm.LastName);
            _page.SignOut();
        }

        [Test, Order(3)]
        public void PasswordIsCaseSensitive()
        {
            var page = new SignInPage(_driver);
            page.LogIn(_email, _password.ToLower());
            page.WaitForAuthenticationErrorMessage();
            page.AssertAuthenticationFailed();
        }

       [Test, Order(4)]
        public void ValidCredentials()
        {
            var page = new SignInPage(_driver);
            page.LogIn(_email, _password);
            page.AssertUserIsLoggedIn(_firstName, _lastName);
        }
        private static string GenerateRandomEmail()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var username = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            var domainName = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            return username + '@' + domainName + ".cz";
        }
    }
}
