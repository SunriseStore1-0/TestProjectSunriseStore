using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;

namespace TestProjectSunriseStore
{
    public class Tests
    {
        private WebDriver WebDriver { get; set; } = null!;
        private string DriverPath { get; set; } = @"C:\Users\mat12\source\chromedriver_win32";
        private string BaseUrl { get; set; } = "http://localhost/Sklepik/loginPage.php";
        private WebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            return new ChromeDriver(DriverPath, options, TimeSpan.FromSeconds(300));
        }
        [SetUp]
        public void Setup()
        {
            WebDriver = GetChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        [TearDown]
        public void TearDown()
        {
            WebDriver.Quit();
        }

        [Test]
        public void Test1()
        {
            //sprawdzenie czy znajdujemy siê na odpowiedniej stronie
            WebDriver.Navigate().GoToUrl(BaseUrl);
            Assert.AreEqual("SunriseStore", WebDriver.Title);
        }
        [Test]
        public void RegisterButtonTest()
        {
            //sprawdzenie czy przechodzimy na odpowiedni¹ stronê
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var radioBregisterButton = WebDriver.FindElement(By.Name("registerButton"));
            radioBregisterButton.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/registerPage.php", currentURL);
        }
        [Test]
        public void ResetButtonTest()
        {
            //sprawdzenie czy resetButton usuwa dane z inputów
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBresetButton = WebDriver.FindElement(By.Name("resetButton"));
            radioBresetButton.Click();
            Assert.AreEqual("", inputUsername.GetAttribute("value"));
            Assert.AreEqual("", inputPassword.GetAttribute("value"));
        }
        [Test]
        public void LoginButtonTest()
        {
            //sprawdzenie poprawnego logowania
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBresetButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBresetButton.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/productsPage.php", currentURL);
        }
        [Test]
        public void LoginUsernameInputTest()
        {
            //sprawdzenie poprawnego logowania
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var radioBresetButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBresetButton.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/loginPage.php", currentURL);
        }
        [Test]
        public void LoginPasswordInputTest()
        {
            //sprawdzenie czy przepuœci nas dalej bez podawania has³a
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBresetButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBresetButton.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/loginPage.php", currentURL);
        }
        [Test]
        public void IncorectDataLoginButtonTest()
        {
            //sprawdzenie poprawnego logowania
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBresetButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBresetButton.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/loginPage.php", currentURL);
        }
    }
}