using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace E2X_test_framework.PageObjects
{
    public class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //page object factory for sign in button
        [FindsBy(How = How.XPath, Using = "//a[@class='navUser-action'][normalize-space()='Sign in']")]
        private IWebElement signIn;

        //page object factory for register button
        [FindsBy(How = How.XPath, Using = "//a[@class='navUser-action'][normalize-space()='Register']")]
        private IWebElement register;


        //this method returns new login page after clicked on sign in button on main page
        public LoginPage clickSignInButton()
        {
            signIn.Click();
            return new LoginPage(driver);
        }

        public IWebElement getSignInButton()
        {

            return signIn;

        }

        public IWebElement getRegisterButton()
        {

            return register;

        }

      

    }
}

