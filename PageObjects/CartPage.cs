using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UnitTestProject1.PageObjects.Controllers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Collections.Generic;
using System.Threading;

namespace UnitTestProject1.PageObjects
{
    public class CartPage
    {
        private IWebDriver driver;
        public LoggedInMenuItemControl menuItemControl => new LoggedInMenuItemControl(driver);

        public CartPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(productTable));
        }

        private By productTable = By.XPath("//table[@class='table table-bordered table-hover table-striped']");
        private IWebElement TableProduct => driver.FindElement(productTable);

        private By products = By.CssSelector("[id='tbodyid'] tr");
        private IList<IWebElement> LstProducts => driver.FindElements(products);

        private By total = By.CssSelector("[id='totalp']");
        private IWebElement LblTotal => driver.FindElement(total);

        private By order = By.CssSelector("[data-target='#orderModal']");
        private IWebElement BtnPlaceOrder => driver.FindElement(order);



        //Calculates total based on each product price
        public double CalculateTotal()
        {
            double total = 0;
            foreach(IWebElement prod in LstProducts)
            {  
                total +=  Convert.ToDouble(prod.FindElement(By.CssSelector("td:nth-of-type(3)")).Text);
            }
            return total;
        }

        //Deletes all the products from the cart
        public void DeleteProducts()
        {
            foreach (IWebElement prod in LstProducts)
            {
                prod.FindElement(By.CssSelector("td:nth-of-type(4)")).FindElement(By.CssSelector("a")).Click();
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[id='tbodyid'] tr")));
            }
        }

        //Returns the total displayed by the site
        public double GetTotalPrice()
        {
            return  Convert.ToDouble(LblTotal.Text);
        }

        public OrderPage NavigateToOrderPage()
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            //wait.Until(ExpectedConditions.ElementToBeClickable(order));
            //Don't know how to wait for that button to become clickable, the solution above does not work...

            Thread.Sleep(1000);
            BtnPlaceOrder.Click();
            return new OrderPage(driver);
        }
    }
}