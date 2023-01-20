using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace E2X_test_framework.PageObjects
{
	public class SearchPage
	{
        IWebDriver driver;

        public SearchPage(IWebDriver driver)
		{
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //page object factory for product on search results
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Add to Cart']")]
        private IWebElement addToCart;


        //this method returns new Cart page after clicked on add to cart button on product on search results
        public CartPage addToCartProduct()
        {

            addToCart.Click();

            return new CartPage(driver);

        }


    }
}

