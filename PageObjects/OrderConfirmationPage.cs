using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace E2X_test_framework.PageObjects
{
	public class OrderConfirmationPage
	{
        IWebDriver driver;

        public OrderConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //page object factory for thank you text
        [FindsBy(How = How.CssSelector, Using = "h1[class='optimizedCheckout-headingPrimary']")]
        private IWebElement ThankYouText;


        //page object factory for order summary
        [FindsBy(How = How.CssSelector, Using = ".cartDrawer.optimizedCheckout-orderSummary")]
        private IWebElement OrderSummary;



        public IWebElement getThankYouText()
        {

            return ThankYouText;

        }

        public IWebElement getOrderSummary()
        {

            return OrderSummary;

        }

    }
}

