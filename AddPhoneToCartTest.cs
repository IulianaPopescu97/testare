using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.PageObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class AddPhoneToCartTest
    {
        private IWebDriver driver;
        private PhonePage phonePage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoblaze.com/");
            var loginPage = new LogInPage(driver);
            loginPage.menuItemControl.NavigateToLogInPage();
            loginPage.LogInApplication("test@uaic.ro", "aTELIETTESTARE1");

            var homePage = new HomePage(driver);

            phonePage = homePage.NavigateToPhonePage();
            var selectPhone = phonePage.NavigateToPhoneDetailPage();
            _ = selectPhone.NavigateToCartPage();
        }

        [TestMethod]
        public void Should_Display_Product_In_Cart()
        { 
            
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
