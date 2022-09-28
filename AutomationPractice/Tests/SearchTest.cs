using AutomationPractice.Pages.Search;
using NUnit.Framework;

namespace AutomationPractice.Tests
{
    internal class SearchTest : TestBase
    { 
        [Test]
        public void SqlInjection()
        {
            var page = new SearchResultsPage(_driver);
            _driver.Manage().Window.Maximize();
            page.SearchString("' or 1=1;");
            page.AssertNotAcceptable();
        }

        [Test]
        public void NonexistentProduct()
        {
            string query = "Actum_Digital";
            var page = new SearchResultsPage(_driver);
            _driver.Manage().Window.Maximize();
            page.SearchString(query);

            page.AssertNoResultFound(query);
        }

        [Test]
        public void ProductTitleHasPrecedence()
        {
            string query = "dress";
            var page = new SearchResultsPage(_driver);
            _driver.Manage().Window.Maximize();
            page.SearchString(query);

            page.AssertProductTitlesWithQueryAppearFirst(query);
        }

        [Test]
        public void PriceHighLowSorting()
        {
            string query = "dress";

            var page = new SearchResultsPage(_driver);
            _driver.Manage().Window.Maximize();
            page.SearchString(query);
            page.SortByPriceDesc();
            page.AssertPricesSortedHighToLow();
        }
    }
}