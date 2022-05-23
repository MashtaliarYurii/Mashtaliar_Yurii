using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task_Selenium
{
    public class Test_Selenium
    {
        IWebDriver webDriver;
        ChromeOptions options;

        [SetUp]
        public void Setup()
        {
            //Entering the site
            options = new ChromeOptions();
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            webDriver = new ChromeDriver(options);
            webDriver.Navigate().GoToUrl("https://www.demoblaze.com/");
            
            //Scenario_1_1
            IWebElement lnkLogin = webDriver.FindElement(By.LinkText("Log in"));
            lnkLogin.Click();
            Thread.Sleep(100);
            var txtUserName = webDriver.FindElement(By.Id("loginusername"));
            Thread.Sleep(100);
            var txtUserPass = webDriver.FindElement(By.Id("loginpassword"));

            Thread.Sleep(100);
            txtUserName.SendKeys("Mashtaliar_Yurii");
            Thread.Sleep(100);
            txtUserPass.SendKeys("yura2802");
            Thread.Sleep(100);
            IWebElement lnkLogin2 = webDriver.FindElement(By.CssSelector("#logInModal .btn-primary"));
            Thread.Sleep(100);
            lnkLogin2.Click();
        }

        [Test]
        public void Test()
        {
            //Scenario_1_2
            Thread.Sleep(1000);
            IWebElement lnkNotebook = webDriver.FindElement(By.LinkText("Laptops"));

            Thread.Sleep(100);
            lnkNotebook.Click();

            //Scenario_1_3
            Thread.Sleep(500);
            IWebElement lnkDell = webDriver.FindElement(By.CssSelector("a[href *= 'prod.html?idp_=12']"));

            Thread.Sleep(100);
            lnkDell.Click();

            //Scenario_1_4
            Thread.Sleep(500);
            IWebElement lnkPurchase = webDriver.FindElement(By.CssSelector(" .btn-success"));
            Thread.Sleep(100);
            lnkPurchase.Click();

            //Scenario_1_5
            Thread.Sleep(500);
            lnkPurchase.SendKeys("{ENTER}");
            Thread.Sleep(500);
            IWebElement lnkCart = webDriver.FindElement(By.CssSelector("a[href *= 'cart.html']"));
            Thread.Sleep(100);
            lnkCart.Click();
            Thread.Sleep(500);
            IWebElement lnkPOrder = webDriver.FindElement(By.CssSelector(" .btn-success"));
            Thread.Sleep(100);
            lnkPOrder.Click();

            //Scenario_1_6
            Thread.Sleep(100);
            var txtPOName = webDriver.FindElement(By.Id("name"));
            Thread.Sleep(100);
            txtPOName.SendKeys("Mashtaliar Yurii");

            Thread.Sleep(100);
            var txtCountry = webDriver.FindElement(By.Id("country"));
            Thread.Sleep(100);
            txtCountry.SendKeys("Ukraine");

            Thread.Sleep(100);
            var txtCity = webDriver.FindElement(By.Id("city"));
            Thread.Sleep(100);
            txtCity.SendKeys("Kyiv");

            Thread.Sleep(100);
            var txtCard = webDriver.FindElement(By.Id("card"));
            Thread.Sleep(100);
            txtCard.SendKeys("5792 2497 0862 1208");

            Thread.Sleep(100);
            var txtMonth = webDriver.FindElement(By.Id("month"));
            Thread.Sleep(100);
            txtMonth.SendKeys("January");

            Thread.Sleep(100);
            var txtYear = webDriver.FindElement(By.Id("year"));
            Thread.Sleep(100);
            txtYear.SendKeys("2022");

            Thread.Sleep(100);
            IWebElement lnkBPurchase = webDriver.FindElement(By.XPath("//button[contains(@onclick,'purchaseOrder')]"));
            Thread.Sleep(100);
            lnkBPurchase.Click();

            Assert.AreEqual(true, (webDriver.FindElements(By.Id("orderModal")).Count == 1));

            webDriver.Quit();
        }
    }
}