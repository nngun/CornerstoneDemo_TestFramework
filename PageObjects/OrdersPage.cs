using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace E2X_test_framework.PageObjects
{
    public class OrdersPage
    {
        IWebDriver driver;

        public OrdersPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }


        //page object factory for title
        [FindsBy(How = How.CssSelector, Using = ".page-heading")]
        private IWebElement OrdersPageTitle;

        //page object factory for Search button
        [FindsBy(How = How.XPath, Using = "//button[@id='quick-search-expand']")]
        private IWebElement searchButton;

        //page object factory for Search field
        [FindsBy(How = How.CssSelector, Using = "#nav-quick-search")]
        private IWebElement searchField;




        public IWebElement getOrdersPageTitle()
        {

            return OrdersPageTitle;

        }

        //reusable method whenever you need to search for a product
        public SearchPage searchByProductName(string product)
        {

            searchButton.Click();
            searchField.SendKeys(product);

            Actions builder = new Actions(driver);
            builder.SendKeys(Keys.Enter);

            return new SearchPage(driver);

        }
    }
}

