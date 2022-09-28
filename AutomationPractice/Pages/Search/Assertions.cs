using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationPractice.Pages.Search
{
    internal partial class SearchResultsPage
    {
        internal void AssertNotAcceptable()
        {
            Assert.AreEqual(_driver.FindElement(_h1By).Text, "Error 406 - Not Acceptable");
        }

        internal void AssertNoResultFound(string query)
        {
            Assert.AreEqual(_driver.FindElement(_headingCounterBy).Text, "0 results have been found.");
            Assert.AreEqual(_driver.FindElement(_alertWarningBy).Text, $"No results were found for your search \"{query}\"");
        }

        internal void AssertProductTitlesWithQueryAppearFirst(string query)
        {
            List<IWebElement> products = _driver.FindElements(_productNameBy).ToList();

            bool isQueryInTitle = true;
            bool queryAppearsFirst = true;

            foreach (var product in products)
            {
                if (product.Text.Contains(query) && !isQueryInTitle)
                    queryAppearsFirst = false;

                else
                    isQueryInTitle = false;
            }
            Assert.True(queryAppearsFirst);
        }

        internal void AssertPricesSortedHighToLow()
        {
            List<IWebElement> prices = _driver.FindElements(_productPrices).ToList();

            double previousPrice = double.MaxValue;

            foreach(var price in prices)
            {
                if (price.Text.Length > 1)
                {
                    double currentPrice = Convert.ToDouble(price.Text.Substring(1));
                    Assert.Greater(previousPrice, currentPrice);
                    previousPrice = currentPrice;
                }                
            }
        }
    }
}
