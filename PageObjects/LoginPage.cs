using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace E2X_test_framework.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //page object factory for email
        [FindsBy(How = How.CssSelector, Using = "#login_email")]
        private IWebElement email;

        //page object factory for password
        [FindsBy(How = How.CssSelector, Using = "#login_pass")]
        private IWebElement password;

        //page object factory for signIn Button
        [FindsBy(How = How.XPath, Using = "//input[@value='Sign in']")]
        private IWebElement signIn;



        public void waitForSigninPageDisplay()

        {
            //wait until Sign In button is available
            //if Sign In button is available, it means that sign in page appears

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@value='Sign in']")));
        }

        //reusable method whenever you need proper valid login
        public OrdersPage validLogin(string mail, string pass)
        {

            //this is loging in and also give us new object for the orders page
            email.SendKeys(mail);
            password.SendKeys(pass);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", signIn);

            //not using below code because it gives “Element is not clickable at point” error
            //signIn.Click();
            return new OrdersPage(driver);

        }

       


    }
}

