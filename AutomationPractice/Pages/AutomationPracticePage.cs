using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractice.Pages
{
    internal abstract class AutomationPracticePage
    {
        private protected readonly IWebDriver _driver;
        private protected readonly WebDriverWait _wait;
        static private protected readonly string _url = "http://automationpractice.com/";
        private protected readonly By _searchBy = By.Id("search_query_top");
        public AutomationPracticePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void SearchString(string stringToSearch)
        {
            if(!_driver.Url.StartsWith(_url))
                GoTo();

            IWebElement searchField = _driver.FindElement(_searchBy);
            searchField.Click();
            searchField.SendKeys(stringToSearch);
            searchField.Submit();
        }

        internal virtual void GoTo()
        {
            _driver.Navigate().GoToUrl(_url);
        }
    }
}
