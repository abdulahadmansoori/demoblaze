using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace demoblaze.Pages
{

    public class CartPage
    {
        private IWebDriver driver;
        private By nameField = By.Id("name");
        private By countryField = By.Id("country");
        private By cityField = By.Id("city");
        private By cardField = By.Id("card");
        private By monthField = By.Id("month");
        private By yearField = By.Id("year");
        private By purchaseButton = By.XPath("//*[@id=\"orderModal\"]/div/div/div[3]/button[2]");
        private By cartItems = By.XPath("//table[@class='table table-striped']/tbody/tr/td[2]");
        private By comfirmOrder = By.XPath("/html/body/div[10]/div[7]/div/button");


        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsItemAdded(string itemName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElements(cartItems).Count > 0);

            var items = driver.FindElements(cartItems);
            foreach (var item in items)
            {
                if (item.Text == itemName)
                {
                    return true;
                }
            }
            return false;
        }
        public void PlaceOrder()
        {
            By placeOrder = By.XPath($"//*[@id=\"page-wrapper\"]/div/div[2]/button");
            WaitAndClick(placeOrder);
        }
        public void PurchaseInfo(string OrderName, string country, string city, string card, string month, string year)
        {
            WaitAndSendKeys(nameField, OrderName);
            WaitAndSendKeys(countryField, country);
            WaitAndSendKeys(cityField, city);
            WaitAndSendKeys(cardField, card);
            WaitAndSendKeys(monthField, month);
            WaitAndSendKeys(yearField, year);
            WaitAndClick(purchaseButton);
        }
        public void ComfirmOrder()
        {
            WaitAndClick(comfirmOrder);
        }
        private void WaitAndSendKeys(By locator, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.FindElement(locator).SendKeys(text);
        }
        private void WaitAndClick(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.FindElement(locator).Click();
        }
    }

    
}
