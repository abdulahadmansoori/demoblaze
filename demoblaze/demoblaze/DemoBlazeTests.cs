using demoblaze.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace DemoBlazeTests
{
    [TestFixture]
    public class DemoBlazeTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        private LoginPage loginPage;
        private CartPage cartPage;

        [SetUp]
        public void Setup()
        {
            // Set up the WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Initialize the page objects
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            cartPage = new CartPage(driver);
        }

        [TearDown]
        public void Teardown()
        {
            // Close the WebDriver
            driver.Quit();
        }

        [Test]
        public void AddToCartTest()
        {
            // Navigate to the home page
            homePage.NavigateTo();

            // Perform login
            homePage.ClickLoginButton();

            // Login to the website
            loginPage.Login("username", "password");

            // Navigate to product details
            homePage.ProductDetail("Samsung galaxy s6");

            // Add an item to the cart
            homePage.AddToCart("Samsung galaxy s6");
            
            // Go to the cart
            homePage.GoToCart();

            // Verify the item is added to the cart
            //NUnit.Framework.Assert.IsTrue(cartPage.IsItemAdded("Samsung galaxy s6"), "Item not added to the cart.");
            
            // Press place order button
            cartPage.PlaceOrder();

            // Insert Required information
            cartPage.PurchaseInfo("ahad", "pakistan", "karachi", "#000000", "06", "2023");

            //Order Confirmation Notification
            cartPage.ComfirmOrder();
        }
    }
}


