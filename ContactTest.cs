using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects;
using UnitTestProject1.PageObjects.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class ContactTest
    {
        private IWebDriver driver;
        private ContactPage contactPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Navigate().GoToUrl("https://demoblaze.com/");
            var menu = new MenuItemControl(driver);
            contactPage = menu.NavigateToContactPage();
        }


        //In this test a message is sent from the Contact page
        //If the resulting message is not the expected one, the test will fail
        [TestMethod]
        public void Should_Fail_When_MessageIsNotSentSuccessfully()
        {
            //Arrange
            string expectedResult = "Thanks for the message!!";

            //Act
            contactPage.SendMessage("testemail@test.com", "Test User", "This is a test message!!");
            var actualResults = driver.SwitchTo().Alert().Text;

            //Assert
            Assert.AreEqual(expectedResult, actualResults);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
