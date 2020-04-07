using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.PageObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;
        private LogInPage logInPage;


        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            logInPage = new LogInPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoblaze.com/");
            logInPage.menuItemControl.NavigateToLogInPage();
        }

        [TestMethod]
        public void LogIn_CorrectEmail_CorrectPassword()
        {
            logInPage.LogInApplication("test@uaic.ro", "aTELIETTESTARE1");

            var expectedResult = "Welcome test@uaic.ro";
            var homePage = new HomePage(driver); 

            Assert.AreEqual(expectedResult, homePage.menuItemControl.welcomeUserEmailText);
        }

        [TestMethod]
        public void Login_IncorrectEmail_IncorrectPassword()
        {
            logInPage.LogInApplication("wrongemail@uaic.ro", "ulalalaa");

            var expectedResult = "User does not exist.";
            var actualResults = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expectedResult, actualResults);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}