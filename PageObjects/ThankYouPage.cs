using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class ThankYouPage
    {
        private IWebDriver driver;

        public ThankYouPage(IWebDriver browser)
        {
            driver = browser;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        private By thankYou = By.CssSelector("[data-has-confirm-button='true'] h2");
        public IWebElement LblThankYou => driver.FindElement(thankYou);

        private By password = By.Id("loginpassword");
        private IWebElement TxtPassword()
        {
            return driver.FindElement(password);
        }

        private By confirm = By.CssSelector("button[class^='confirm']");
        private IWebElement BtnConfirm => driver.FindElement(confirm);

        public void Confirm()
        {
            BtnConfirm.Click();
        }


    }
}

