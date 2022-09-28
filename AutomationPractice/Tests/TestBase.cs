using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationPractice.Tests
{
    [TestFixture]
    public class TestBase
    {
        private protected IWebDriver _driver;

        public TestBase() { }

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver("C:\\Programs");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _driver.Dispose();
        }
    }
}
