using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UnitTestProject1.PageObjects.Controllers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using UnitTestProject1.PageObjects.Order;

namespace UnitTestProject1.PageObjects
{
    public class OrderPage
    {
        private IWebDriver driver;

        public OrderPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(name)); 
        }

        private By name = By.Id("name");
        private IWebElement TxtName()
        {
            return driver.FindElement(name);
        }

        private By country = By.Id("country");
        private IWebElement TxtCountry()
        {
            return driver.FindElement(country);
        }

        private By city = By.Id("city");
        private IWebElement TxtCity()
        {
            return driver.FindElement(city);
        }

        private By card = By.Id("card");
        private IWebElement TxtCard()
        {
            return driver.FindElement(card);
        }

        private By month = By.Id("month");
        private IWebElement TxtMonth()
        {
            return driver.FindElement(month);
        }

        private By year = By.Id("year");
        private IWebElement TxtYear()
        {
            return driver.FindElement(year);
        }

        private By purchase = By.CssSelector("button[onclick^='purchaseOrder']");
        private IWebElement BtnPurchase => driver.FindElement(purchase);


        public ThankYouPage SubmitDetails(OrderBO customerDetails)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(name));

            TxtName().SendKeys(customerDetails.TxtName);
            TxtCountry().SendKeys(customerDetails.TxtCountry);
            TxtCity().SendKeys(customerDetails.TxtCity);
            TxtCard().SendKeys(customerDetails.TxtCard);
            TxtMonth().SendKeys(customerDetails.TxtMonth);
            TxtYear().SendKeys(customerDetails.TxtYear);
            BtnPurchase.Click();
            return new ThankYouPage(driver);
        }

    }
}