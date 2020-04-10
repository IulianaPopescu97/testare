using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UpdateCart
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        public static string BaseURL { get { return baseURL; } set => baseURL = value; }


        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void SetUp()
        {
            verificationErrors = new StringBuilder();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Navigate().GoToUrl("https://demoblaze.com/");
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheUpdateCartTest()
        {
            driver.Navigate().GoToUrl("https://demoblaze.com/index.html");
            driver.FindElement(By.Id("login2")).Click();
            driver.FindElement(By.Id("loginusername")).Click();
            driver.FindElement(By.Id("loginusername")).Clear();
            driver.FindElement(By.Id("loginusername")).SendKeys("mariusvornicu");
            driver.FindElement(By.Id("loginpassword")).Clear();
            driver.FindElement(By.Id("loginpassword")).SendKeys("demoblazetest");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("(//button[@type='button'])[9]")).Click();
            driver.FindElement(By.LinkText("Monitors")).Click();
            driver.FindElement(By.LinkText("Apple monitor 24")).Click();
            driver.FindElement(By.LinkText("Add to cart")).Click();
            Assert.AreEqual("Product added.", CloseAlertAndGetItsText());
            driver.FindElement(By.LinkText("Add to cart")).Click();
            Assert.AreEqual("Product added.", CloseAlertAndGetItsText());
            driver.FindElement(By.LinkText("Add to cart")).Click();
            Assert.AreEqual("Product added.", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("cartur")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Delete')])[3]")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
