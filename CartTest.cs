using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects;
using UnitTestProject1.PageObjects.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class CartTest
    {
        private IWebDriver driver;
        private HomePage homePage;
        private MenuItemControl menu;
        private CartPage cart;

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


        //'actualTotal' is calculated based on each product individual price
        //'expectedTotal' is the total price displayed by the site
        //if the two values are not equal the test will fail
        [TestMethod]
        public void Should_Fail_When_CalculatedTotalNotEqualWithDisplayedTotal()
        {
            //Two random products added to the cart (based on their order on the homepage)
            //Arrange
            var firstProduct = homePage.GoToSpecificProduct(3);
            firstProduct.addPhoneToCart();
            homePage = menu.NavigateToHomePage();
            var secondProduct = homePage.GoToSpecificProduct(6);
            secondProduct.addPhoneToCart();

            //Act
            cart = menu.NavigateToCart();
            Thread.Sleep(1000); //Haven't found a method to wait for table to fully load
            var actualTotal = cart.CalculateTotal();
            var expectedTotal = cart.GetTotalPrice();

            //Assert
            Assert.AreEqual(actualTotal, expectedTotal);
        }

        [TestCleanup]
        public void CleanUp()
        {
            //This method deletes all the products in the cart.
            cart.DeleteProducts();
            driver.Quit();
        }
    }
}
