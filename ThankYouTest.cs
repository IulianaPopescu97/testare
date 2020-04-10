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
using UnitTestProject1.PageObjects.Order;

namespace UnitTestProject1
{
    [TestClass]
    public class ThankYouTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private MenuItemControl menu;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Navigate().GoToUrl("https://demoblaze.com/");
            var loginPage = new LogInPage(driver);
            loginPage.menuItemControl.NavigateToLogInPage();
            menu = new MenuItemControl(driver);
            loginPage.LogInApplication("test@test.eu", "testare");
            homePage = new HomePage(driver);
        }


        //In this test an order is placed
        //If the resulting message is not the expected one, the test will fail
        [TestMethod]
        public void Should_Fail_When_ThankYouMessageIsNotDisplayed()
        {
            //Arrange
            string expectedResult = "Thank you for your purchase!";
            OrderBO customerDetails = new OrderBO();

            //Act
            var cart = menu.NavigateToCart();
            var orderPage = cart.NavigateToOrderPage();
            var thankYouPage =  orderPage.SubmitDetails(customerDetails);
            var actualResult = thankYouPage.LblThankYou.Text;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
