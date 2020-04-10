using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using UnitTestProject1.PageObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class PrevOrder
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
        }
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
        public void InitializeTest()
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
        public void ThePrevOrderTest()
        {
            driver.FindElement(By.XPath("(//button[@type='button'])[9]")).Click();
            driver.FindElement(By.LinkText("Sony vaio i7")).Click();
            driver.FindElement(By.LinkText("Add to cart")).Click();
            Assert.AreEqual("Product added.", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("cartur")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Delete')])[2]")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[30]")).Click();
            driver.FindElement(By.Id("name")).Click();
            driver.FindElement(By.Id("name")).Clear();
            driver.FindElement(By.Id("name")).SendKeys("Nume Persoana");
            driver.FindElement(By.Id("country")).Clear();
            driver.FindElement(By.Id("country")).SendKeys("Romania");
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("Iasi");
            driver.FindElement(By.Id("card")).Clear();
            driver.FindElement(By.Id("card")).SendKeys("4xxx-xxxx-xxxx-xxx0");
            driver.FindElement(By.Id("month")).Click();
            driver.FindElement(By.Id("month")).Clear();
            driver.FindElement(By.Id("month")).SendKeys("02");
            driver.FindElement(By.Id("year")).Click();
            driver.FindElement(By.Id("year")).Clear();
            driver.FindElement(By.Id("year")).SendKeys("2020");
            driver.FindElement(By.XPath("(//button[@type='button'])[9]")).Click();
            driver.FindElement(By.XPath("//div[7]/div/button")).Click();
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