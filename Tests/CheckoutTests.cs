using System;
using E2X_test_framework.utilities;
using E2X_test_framework.PageObjects;


namespace E2X_test_framework.Tests
{
    public class CheckoutTests : Base
	{
        [Test, TestCaseSource("AddTestData")]
        [Parallelizable(ParallelScope.All)]
        public void CheckoutTest_LoginFirst(string email, string password, string product, string name)
		{
            //go to the website
            MainPage mainPage = new MainPage(getDriver());

            //check sign in and register buttons are available on top navigation
            Boolean ExpectedResult = true;
            Assert.AreEqual(ExpectedResult, mainPage.getSignInButton().Displayed);
            Assert.AreEqual(ExpectedResult, mainPage.getRegisterButton().Displayed);

            //click on sign in button
            LoginPage loginPage = mainPage.clickSignInButton();

            //wait for sign in page to be displayed
            loginPage.waitForSigninPageDisplay();

            //call proper login method with test data
            OrdersPage ordersPage = loginPage.validLogin(email, password);

            string expectedTitle = "Orders";

            //check if you are directed to orders page correctly
            Assert.AreEqual(expectedTitle, ordersPage.getOrdersPageTitle().Text);

            //click on Search button and search by the product name which comes from test data
            SearchPage searchPage = ordersPage.searchByProductName(product);

            //add this product to cart
            CartPage cartPage = searchPage.addToCartProduct();

            //go to checkout with this product
            CheckoutPage checkoutPage = cartPage.goToCheckoutPage();

            //on checkout page, check if email is equal to email address which is used for login
            Assert.AreEqual(email, checkoutPage.getCheckOutEmail().Text);

            //wait for page to be loaded and continue button is clickable
            checkoutPage.waitForContinueButtonDisplay();

            //check if continue button successfully appears on checkout page
            Assert.AreEqual(ExpectedResult, checkoutPage.getContinueButton().Displayed);

            //click on continue button
            checkoutPage.clickContinueButton();

            //wait for page to be loaded and credit card details fields appear successfully
            checkoutPage.waitForAddCardDetailsDisplay();

            //check if complete checkout button successfully appears on checkout page after clicking on continue
            Assert.AreEqual(ExpectedResult, checkoutPage.getCompleteCheckoutButton().Displayed);

            //add credit card details which come from test data
            checkoutPage.addCardDetails();

            //complete checkout
            OrderConfirmationPage orderConfirmationPage = checkoutPage.completeCheckout();

            //check that after checkout completion, user is directed to order confirmation page successfully
            string ThankYouText = orderConfirmationPage.getThankYouText().Text;
            TestContext.Progress.WriteLine(ThankYouText);
    
            //check if thank you page includes user name which is used for login
            StringAssert.Contains(name, ThankYouText);

            //check if user is on order confirmation page by checking current URL
            string currentURL = driver.Value.Url;
            TestContext.Progress.WriteLine(currentURL);
            string expectedTextOnURL = "order-confirmation";
            StringAssert.Contains(expectedTextOnURL, currentURL);

        }



        public static IEnumerable<TestCaseData> AddTestData()

        {

            yield return new TestCaseData(getDataParser().extractData("email"), getDataParser().extractData("password"), getDataParser().extractData("product"), getDataParser().extractData("name"));
        }


    }
}

