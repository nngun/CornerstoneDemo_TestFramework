using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace E2X_test_framework.utilities
{
    public class Base
    {
 
        String browserName;
        String testUrl;
       
        // public IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        [SetUp]

        public void StartBrowser()

        {

            //tests will be run on the browser which comes from parametric value in App.config file
            browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            testUrl = ConfigurationManager.AppSettings["url"];
            //tests will be run on the url which comes from parametric value in App.config file
            driver.Value.Url = testUrl;
            //once tests start to run, cookies pop up will be closed by clicking on accept all cookies button
            driver.Value.FindElement(By.XPath("//button[normalize-space()='Accept All Cookies']")).Click();


        }

        public IWebDriver getDriver()

        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)

        {

            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;


                case "Edge":

                    driver.Value = new EdgeDriver();
                    break;

            }


        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
        }

        [TearDown]
        public void AfterTest()

        {
            driver.Value.Quit();
        }


    }
}

