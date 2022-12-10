using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Test3
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void The3Test()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("sugljesic@etfos.hr");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("blabla");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Forgot password?'])[1]/following::div[3]")).Click();
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();
            driver.FindElement(By.XPath("//li[@id='topcartlink']/a/span")).Click();
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/cart");
            driver.FindElement(By.Id("CountryId")).Click();
            new SelectElement(driver.FindElement(By.Id("CountryId"))).SelectByText("Croatia");
            driver.FindElement(By.Name("estimateshipping")).Click();
            driver.FindElement(By.Id("termsofservice")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/login/checkoutasguest?returnUrl=%2Fcart");
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
