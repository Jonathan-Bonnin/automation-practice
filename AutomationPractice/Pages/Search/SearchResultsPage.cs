using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.Pages.Search
{
    internal partial class SearchResultsPage : AutomationPracticePage
    {
        private readonly By _h1By = By.TagName("h1");
        private readonly By _headingCounterBy = By.ClassName("heading-counter");
        private readonly By _alertWarningBy = By.ClassName("alert-warning");
        private readonly By _productNameBy = By.ClassName("product-name");
        private readonly By _selectProductSortBy = By.Id("selectProductSort");
        private readonly By _productPrices = By.XPath("//*[@itemprop='price']");

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }
 
        internal void SortByPriceDesc()
        {   
            SelectElement productDropdown = new SelectElement(_driver.FindElement(_selectProductSortBy));
            productDropdown.SelectByValue("price:desc");
        }

    }
}
