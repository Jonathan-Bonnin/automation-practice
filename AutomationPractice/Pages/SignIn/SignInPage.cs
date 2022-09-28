using OpenQA.Selenium;
using System;

namespace AutomationPractice.Pages.SignIn
{
    internal partial class SignInPage : AutomationPracticePage
    {
        private readonly string _authenticationUrl = _url + "index.php?controller=authentication";
        private readonly By _createAccountEmailBy = By.Id("email_create");
        private readonly By _signInEmailBy = By.Id("email");
        private readonly By _signInPasswordBy = By.Id("passwd");
        private readonly By _createAccountErrorMessageBy = By.Id("create_account_error");
        private readonly By _mrBy = By.Id("id_gender");
        private readonly By _mrsBy = By.Id("id_gender2");
        private readonly By _firstNameBy = By.Id("customer_firstname");
        private readonly By _lastNameBy = By.Id("customer_lastname");
        private readonly By _passwordBy = By.Id("passwd");
        private readonly By _addressFirstNameBy = By.Id("firstname");
        private readonly By _addressLastNameBy = By.Id("lastname");
        private readonly By _addressLine1By = By.Id("address1");
        private readonly By _cityBy = By.Id("city");
        private readonly By _postalCodeBy = By.Id("postcode");
        private readonly By _mobilePhoneBy = By.Id("phone_mobile");
        private readonly By _addressAliasBy = By.Id("alias");
        private readonly By _addressStateBy = By.Id("id_state");
        private readonly By _countryBy = By.Id("id_country");
        private readonly By _submitBy = By.Id("submitAccount"); 
        private readonly By _logInBy = By.Id("SubmitLogin");
        private readonly By _signOutBy = By.ClassName("logout");

        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        internal void SignOut()
        {
            IWebElement signOut = _driver.FindElement(_signOutBy);
            signOut.Click();
        }

        private readonly By _accountNameBy = By.ClassName("account");
        private readonly By _authenticationErrorBy = By.XPath("//*[@id=\"center_column\"]/div[1]/ol/li");

        internal void SubmitForm()
        {
            IWebElement submitButton = _driver.FindElement(_submitBy);
            submitButton.Click();
        }

        internal void LogIn(string email, string password)
        {
            if (_driver.Url != _authenticationUrl)
                GoTo();

            IWebElement emailField = _driver.FindElement(_signInEmailBy);
            emailField.Clear();
            emailField.SendKeys(email);

            IWebElement passwordField = _driver.FindElement(_signInPasswordBy);
            passwordField.Clear();
            passwordField.SendKeys(password);

            _driver.FindElement(_logInBy).Click();
        }

        internal void FillInForm(SignInForm validForm)
        {
            _driver.FindElement(_firstNameBy).SendKeys(validForm.FirstName);
            _driver.FindElement(_lastNameBy).SendKeys(validForm.LastName);
            _driver.FindElement(_passwordBy).SendKeys(validForm.Password);
            _driver.FindElement(_addressLine1By).SendKeys(validForm.AddressLine1);
            _driver.FindElement(_cityBy).SendKeys(validForm.City);
            _driver.FindElement(_postalCodeBy).SendKeys(validForm.PostalCode);
            _driver.FindElement(_mobilePhoneBy).SendKeys(validForm.MobilePhone);
            _driver.FindElement(_addressStateBy).SendKeys(validForm.State);
        }

        internal override void GoTo()
        {
            _driver.Navigate().GoToUrl(_authenticationUrl);
        }

        internal void SubmitCreateEmail(string email)
        {
            if (_driver.Url != _authenticationUrl)
                GoTo();

            IWebElement emailField = _driver.FindElement(_createAccountEmailBy);
            emailField.Click();
            emailField.Clear();
            emailField.SendKeys(email);
            emailField.Submit();
        }
        internal void WaitForCreateAccountErrorMessage()
        {
            _wait.Until(_driver => _driver.FindElement(_createAccountErrorMessageBy).Text.Length > 0);
        }

        internal void WaitForAuthenticationErrorMessage()
        {
            _wait.Until(_driver => _driver.FindElement(_authenticationErrorBy).Text.Length > 0);
        }

        internal void WaitUntilEmailIsPrefilled()
        {
            _wait.Until(_driver => _driver.FindElement(_signInEmailBy).GetAttribute("value").Length > 0);
        }

        internal void WaitUntilUrlChanges()
        {
            _wait.Until(_driver => _driver.Url != _authenticationUrl);
        }
    }
}
