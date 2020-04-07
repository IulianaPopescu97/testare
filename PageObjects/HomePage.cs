using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UnitTestProject1.PageObjects.Controllers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        public LoggedInMenuItemControl menuItemControl => new LoggedInMenuItemControl(driver);

        public HomePage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(welcomeUserEmail));
        }

        private By welcomeUserEmail = By.Id("nameofuser");
        private IWebElement LblWelcomeUserEmail => driver.FindElement(welcomeUserEmail);

        private By cart = By.Id("cartur");
        private IWebElement BtnCart => driver.FindElement(cart);

        public CartPage NavigateToCartPage()
        {
            BtnCart.Click();
            return new CartPage(driver);
        }
    }
}