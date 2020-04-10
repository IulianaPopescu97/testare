using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using UnitTestProject1.PageObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class Aboutus
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
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheAboutusTest()
        {
            driver.Navigate().GoToUrl("https://demoblaze.com/index.html");
            driver.FindElement(By.Id("login2")).Click();
            driver.FindElement(By.Id("loginusername")).Click();
            driver.FindElement(By.Id("loginusername")).Clear();
            driver.FindElement(By.Id("loginusername")).SendKeys("mariusvornicu");
            driver.FindElement(By.Id("loginpassword")).Clear();
            driver.FindElement(By.Id("loginpassword")).SendKeys("demoblazetest");
            driver.FindElement(By.XPath("(//button[@type='button'])[9]")).Click();
            driver.FindElement(By.LinkText("About us")).Click();
            driver.FindElement(By.XPath("//div[@id='example-video']/button/span")).Click();
            driver.FindElement(By.XPath("//div[@id='example-video']/div[4]/div/div")).Click();
            driver.FindElement(By.XPath("//div[@id='example-video']/div[4]/button[4]/span")).Click();
            driver.FindElement(By.XPath("//div[@id='example-video']/div[4]/button[4]/span")).Click();
            driver.FindElement(By.XPath("//div[@id='example-video']/div[4]/button/span")).Click();
            driver.FindElement(By.XPath("(//button[@type='button'])[25]")).Click();
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
