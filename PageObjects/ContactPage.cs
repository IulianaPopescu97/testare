using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class ContactPage
    {
        private IWebDriver driver;

        public ContactPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private By email = By.Id("recipient-email");
        private IWebElement TxtContactEmail()
        {
            return driver.FindElement(email);
        }

        private By name = By.Id("recipient-name");
        private IWebElement TxtContactName()
        {
            return driver.FindElement(name);
        }

        private By message = By.Id("message-text");
        private IWebElement TxtContactMessage()
        {
            return driver.FindElement(message);
        }

        private By send = By.XPath("//button[@onclick='send()']");
        private IWebElement BtnSendMessage()
        {
            return driver.FindElement(send);
        }


        public void SendMessage(string email, string name, string message)
        {
            TxtContactEmail().SendKeys(email);
            TxtContactName().SendKeys(name);
            TxtContactMessage().SendKeys(message);
            BtnSendMessage().Click();
        }
    }
}
