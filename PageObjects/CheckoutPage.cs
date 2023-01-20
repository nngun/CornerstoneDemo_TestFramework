using System;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using E2X_test_framework.utilities;
using OpenQA.Selenium.Interactions;

namespace E2X_test_framework.PageObjects
{
	public class CheckoutPage : Base
	{
        IWebDriver driver;

        public CheckoutPage(IWebDriver driver)
		{
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        //page object factory for email
        [FindsBy(How = How.XPath, Using = "//div[@class='customerView-body optimizedCheckout-contentPrimary']")]
        private IWebElement checkOutEmail;

        //page object factory for continue button
        [FindsBy(How = How.XPath, Using = "//button[@id='checkout-shipping-continue']")]
        private IWebElement continueButton;


        //page object factory for cardNumber
        [FindsBy(How = How.XPath, Using = "//input[@id='ccNumber']")]
        private IWebElement cardNumber;

        //page object factory for cardExpiry
        [FindsBy(How = How.CssSelector, Using = "#ccExpiry")]
        private IWebElement cardExpiry;


        //page object factory for cardName
        [FindsBy(How = How.CssSelector, Using = "#ccName")]
        private IWebElement cardName;

        //page object factory for cardName
        [FindsBy(How = How.CssSelector, Using = "#ccCvv")]
        private IWebElement cardCVV;

        //page object factory for completeCheckout
        [FindsBy(How = How.CssSelector, Using = "#checkout-payment-continue")]
        private IWebElement completeCheckoutButton;


        public void waitForContinueButtonDisplay()

        {
            //wait until continue button is available

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='checkout-shipping-continue']")));
        }



        public IWebElement getCheckOutEmail()
        {

            return checkOutEmail;

        }


        public void clickContinueButton()
        {
            //to avoid Element Click Intercepted Exception error, I used javascript executer 
            //first scroll down to continue button
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", continueButton);


            //then click on continue button
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
            js2.ExecuteScript("arguments[0].click();", continueButton);

        }


        public void waitForAddCardDetailsDisplay()

        {
            //wait until complete checkout button is available
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", completeCheckoutButton);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#checkout-payment-continue")));
        }


        //this method adds test credit card details by retrieving test data from TestData.json
        public void addCardDetails()
        {

            string cardNameValue = getDataParser().extractData("cardName");
            string cardNumberValue = getDataParser().extractData("cardNumber");
            string cardExpirationValue = getDataParser().extractData("cardExpiration");
            string cardCVVValue = getDataParser().extractData("cardCVV");

            cardNumber.SendKeys(cardNumberValue);
            cardExpiry.SendKeys(cardExpirationValue);
            cardName.SendKeys(cardNameValue);
            cardCVV.SendKeys(cardCVVValue);


        }

        //this method returns new order confirmation page after clicked on complete checkout button on checkout page
        public OrderConfirmationPage completeCheckout()
        {
            //to avoid Element Click Intercepted Exception error, I used javascript executer 
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
            js2.ExecuteScript("arguments[0].click();", completeCheckoutButton);
            return new OrderConfirmationPage(driver);

        }


        public IWebElement getCompleteCheckoutButton()
        {

            return completeCheckoutButton;

        }

        public IWebElement getContinueButton()
        {

            return continueButton;

        }

    }
}

