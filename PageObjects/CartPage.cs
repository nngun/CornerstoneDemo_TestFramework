using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace E2X_test_framework.PageObjects
{
	public class CartPage
	{
        IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        //page object factory for proceed to Checkout button
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Check out']")]
        private IWebElement CheckOutButton;


        //this method returns new checkout page after clicked on check out button on cart page
        public CheckoutPage goToCheckoutPage()
        {

            CheckOutButton.Click();

            return new CheckoutPage(driver);

        }



    }
}

