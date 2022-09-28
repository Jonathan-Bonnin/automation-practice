using NUnit.Framework;

namespace AutomationPractice.Pages.SignIn
{
    internal partial class SignInPage
    {
        internal void AssertAccountAlreadyExists()
        {            
            var actualErrorMessage = _driver.FindElement(_createAccountErrorMessageBy).Text;
            var expectedErrorMessage = "An account using this email address has already" +
                " been registered. Please enter a valid password or request a new one.";
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        internal void AssertAuthenticationFailed()
        {
            var actualErrorMessage = _driver.FindElement(_authenticationErrorBy).Text;
            var expectedErrorMessage = "Authentication failed.";
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        internal void AssertRedirectedToAccountCreation()
        {
            var expectedUrl = _authenticationUrl + "#account-creation";
            var actualUrl = _driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        internal void AssertUserIsLoggedIn(string firstName, string lastName)
        {
            var actualName = _driver.FindElement(_accountNameBy).Text;
            var expectedName = $"{firstName} {lastName}";
            Assert.AreEqual(expectedName, actualName);
        }

        internal void AssertEmailIsAlreadyFilled(string expectedEmail)
        {
            var actualEmail = _driver.FindElement(_signInEmailBy).GetAttribute("value");
            Assert.AreEqual(expectedEmail, actualEmail);
        }
    }
} 