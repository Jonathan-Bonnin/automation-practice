using OpenQA.Selenium;

namespace AutomationPractice.Pages.ContactUs
{
    internal partial class ContactUsPage : AutomationPracticePage
    {
        private readonly string _contactUsUrl = _url + "index.php?controller=contact";
        private readonly By _messageBy = By.Id("message");
        private readonly By _emailBy = By.Id("email");
        private readonly By _orderBy = By.Id("id_order");
        private readonly By _attachFileBy = By.Id("uniform-fileUpload");
        private readonly By _contactTeamBy = By.Id("id_contact");
        private readonly By _submitBy = By.Id("submitMessage");
        private readonly By _altertDangerMessageBy = By.XPath("//*[@class=\"alert alert-danger\"]/ol/li");
        private readonly By _alertSuccessMessageBy = By.ClassName("alert-success");

        public ContactUsPage(IWebDriver driver) : base(driver)
        {
        }

        internal override void GoTo()
        {
            _driver.Navigate().GoToUrl(_contactUsUrl);
        }
        internal void SubmitForm()
        {
            IWebElement _submitButton = _driver.FindElement(_submitBy);
            _submitButton.Click();
        }

        internal void FillInForm(ContactUsForm contactUsForm)
        {
            if (_driver.Url != _contactUsUrl)
                GoTo();

            var message = contactUsForm.Message;
            if(message != null)
            {
                IWebElement _messageField = _driver.FindElement(_messageBy);
                _messageField.Click();
                _messageField.SendKeys(message);
            }

            var email = contactUsForm.Email;
            if(email != null)
            {
                IWebElement _emailField = _driver.FindElement(_emailBy);
                _emailField.Click();
                _emailField.Clear();
                _emailField.SendKeys(email);
            }

            var orderNumber = contactUsForm.OrderNumber;
            if(orderNumber != null)
            {
                IWebElement _orderField = _driver.FindElement(_orderBy);
                _orderField.Click();
                _orderField.SendKeys(orderNumber);
            }

            var filePath = contactUsForm.FilePath;
            if(filePath != null)
            {
                IWebElement _fileField = _driver.FindElement(_attachFileBy);
                _fileField.Click();
                _fileField.SendKeys(filePath);
            }

            var internalTeam = contactUsForm.InternalTeam;
            if(internalTeam != null)
            {
                IWebElement _internalTeamField = _driver.FindElement(_contactTeamBy);
                _internalTeamField.Click();
                _internalTeamField.SendKeys(internalTeam.Name);
            }
        }
    }
}
