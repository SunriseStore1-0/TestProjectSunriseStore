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
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/loginPage.php", currentURL);
        }
        [Test]
        public void StarterButtonTest()
        {
            //sprawdzenie czy przechodzimy na odpowiedni¹ stronê
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var radioBstartButton = WebDriver.FindElement(By.Name("startButton"));
            radioBstartButton.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/registerPage.php", currentURL);
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
        //
        //register page test
        //
        [Test]
        public void LoginButtonTestR()
        {
            //sprawdzenie czy loginButton przechodzi na odpowiedni¹ stronê
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var radioBregisterButton = WebDriver.FindElement(By.Name("loginButton"));
            radioBregisterButton.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/loginPage.php?err=0", currentURL);
        }
        [Test]
        public void ResetButtonTestR()
        {
            //sprawdzenie czy resetButton usuwa dane z inputów
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var inputRPassword = WebDriver.FindElement(By.Name("repassword"));
            inputRPassword.Clear();
            inputRPassword.SendKeys("test");
            var inputmail = WebDriver.FindElement(By.Name("mail"));
            inputmail.Clear();
            inputmail.SendKeys("test@test.pl");
            var inputaddress = WebDriver.FindElement(By.Name("address"));
            inputaddress.Clear();
            inputaddress.SendKeys("testowa 13");
            var inputpostcode = WebDriver.FindElement(By.Name("postcode"));
            inputpostcode.Clear();
            inputpostcode.SendKeys("05-500");
            var radioBresetButton = WebDriver.FindElement(By.Name("resetButton"));
            radioBresetButton.Click();
            Assert.AreEqual("", inputUsername.GetAttribute("value"));
            Assert.AreEqual("", inputPassword.GetAttribute("value"));
            Assert.AreEqual("", inputRPassword.GetAttribute("value"));
            Assert.AreEqual("", inputmail.GetAttribute("value"));
            Assert.AreEqual("", inputaddress.GetAttribute("value"));
            Assert.AreEqual("", inputpostcode.GetAttribute("value"));
        }
        [Test]
        public void SubmitButtonTestR()
        {
            //sprawdzenie czy resetButton usuwa dane z inputów
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var inputRPassword = WebDriver.FindElement(By.Name("repassword"));
            inputRPassword.Clear();
            inputRPassword.SendKeys("test");
            var inputmail = WebDriver.FindElement(By.Name("mail"));
            inputmail.Clear();
            inputmail.SendKeys("test@test.pl");
            var inputaddress = WebDriver.FindElement(By.Name("address"));
            inputaddress.Clear();
            inputaddress.SendKeys("testowa 13");
            var inputpostcode = WebDriver.FindElement(By.Name("postcode"));
            inputpostcode.Clear();
            inputpostcode.SendKeys("05-500");
            var radioBsubmitButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBsubmitButton.Click();
            Thread.Sleep(5000);
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/loginPage.php?err=0", currentURL);
        }
        //
        //main page test
        //
        [Test]
        public void TestMain()
        {
            //sprawdzenie czy znajdujemy siê na odpowiedniej stronie
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBsubmitButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBsubmitButton.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/productsPage.php", currentURL);
        }
        [Test]
        public void TestHomeButton()
        {
            //sprawdzenie czy znajdujemy siê na odpowiedniej stronie
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBsubmitButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBsubmitButton.Click();
            var radioBwedki = WebDriver.FindElement(By.Id("wedki"));
            radioBwedki.Click();
            var radioBwedka1 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[1]/a"));
            radioBwedka1.Click();
            var radioBhome = WebDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/a[3]"));
            radioBhome.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/productsPage.php", currentURL);
        }
        [Test]
        public void TestCartButton()
        {
            //sprawdzenie czy znajdujemy siê na stronie koszyka
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBsubmitButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBsubmitButton.Click();
            var radioBhome = WebDriver.FindElement(By.XPath("/html/body/div[1]/a/div"));
            radioBhome.Click();
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/koszykPage.php", currentURL);
        }
        [Test]
        public void TestSearchAll()
        {
            //sprawdzenie czy znajdujemy siê na odpowiedniej stronie
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBsubmitButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBsubmitButton.Click();
            var radioBproduct1 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[1]/a"));
            var radioBproduct2 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[2]/a"));
            var radioBproduct3 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[3]/a"));
            var radioBproduct4 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[4]/a"));
            var radioBproduct5 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[5]/a"));
            var radioBproduct6 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[6]/a"));
            var radioBproduct7 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[7]/a"));
            var radioBproduct8 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[8]/a"));
            var radioBproduct9 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[9]/a"));
            var radioBproduct10 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[10]/a"));
            var radioBproduct11 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[11]/a"));
            var radioBproduct12 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[12]/a"));
            var radioBproduct13 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[13]/a"));
            var radioBproduct14 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[14]/a"));
            var radioBproduct15 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[15]/a"));
            var radioBproduct16 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[16]/a"));
            var radioBproduct17 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[17]/a"));
            var radioBproduct18 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[18]/a"));
            var radioBproduct19 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[19]/a"));
            var radioBproduct20 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[20]/a"));
            var radioBproduct21 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[21]/a"));
            var radioBproduct22 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[22]/a"));
            var radioBproduct23 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[23]/a"));
            var radioBproduct24 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[24]/a"));
            var radioBproduct25 = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[25]/a"));
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/productsPage.php", currentURL);
        }
        [Test]
        public void SearchTest()
        {
            //sprawdzenie czy znajdujemy siê na odpowiedniej stronie
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("serch"));
            inputUsername.Clear();
            inputUsername.SendKeys("Wobler Jaxon Atract Aris");
            var radioBsearch = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div[2]/form/button"));
            radioBsearch.Click();
            var radioBproduct = WebDriver.FindElement(By.XPath("/ html / body / div[2] / div / div[2] / div[1] / div / a"));
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/productsPage.php", currentURL);
        }
        //
        //koszyk tests
        //

        [Test]
        public void SearchTestK()
        {
            //sprawdzenie czy znajdujemy siê na odpowiedniej stronie
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBsubmitButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBsubmitButton.Click();
            var inputSearch = WebDriver.FindElement(By.Name("serch"));
            inputSearch.Clear();
            inputSearch.SendKeys("Wêdka Mikado Intro Carp II 390");
            var radioBsearch = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div[2]/form/button"));
            radioBsearch.Click();
            var radioBproduct = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div/button"));
            radioBproduct.Click();
            radioBproduct.Click();
            var radioBkoszyk = WebDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/a/div"));
            radioBkoszyk.Click();
            var radioBkoszykCena = WebDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[1]/div/a"));
            Assert.AreEqual("http://localhost/Sklepik/productRev.php?id=1", radioBkoszykCena.GetAttribute("href"));
        }
        [Test]
        public void SearchTestsSubmit()
        {
            //sprawdzenie czy znajdujemy siê na odpowiedniej stronie
            WebDriver.Navigate().GoToUrl(BaseUrl);
            var inputUsername = WebDriver.FindElement(By.Name("username"));
            inputUsername.Clear();
            inputUsername.SendKeys("test");
            var inputPassword = WebDriver.FindElement(By.Name("password"));
            inputPassword.Clear();
            inputPassword.SendKeys("test");
            var radioBsubmitButton = WebDriver.FindElement(By.Name("submitButton"));
            radioBsubmitButton.Click();
            var inputSearch = WebDriver.FindElement(By.Name("serch"));
            inputSearch.Clear();
            inputSearch.SendKeys("Wêdka Mikado Intro Carp II 390");
            var radioBsearch = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/div[2]/form/button"));
            radioBsearch.Click();
            var radioBproduct = WebDriver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[1]/div/button"));
            radioBproduct.Click();
            radioBproduct.Click();
            var radioBkoszyk = WebDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/a/div"));
            radioBkoszyk.Click();
            var radioBZaplac = WebDriver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/div[2]/button"));
            radioBZaplac.Click();
            Thread.Sleep(5000);
            String currentURL = WebDriver.Url;
            Assert.AreEqual("http://localhost/Sklepik/productsPage.php", currentURL);
        }
    }
}