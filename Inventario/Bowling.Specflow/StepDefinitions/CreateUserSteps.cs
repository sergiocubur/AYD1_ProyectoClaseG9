using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Bowling.Specflow.StepDefinitions
{
    [Binding]
    public class CreateUserSteps
    {
        public IWebDriver driver;
        public int mil = 2000;

        [Given(@"Lunch navigator Chrome usr")]
        public void GivenLunchNavigatorChromeUsr()
        {
            //lauch brouser
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"E:\", "chromedriver.exe");
            driver = new ChromeDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
        }
        
        [Given(@"Navigate to localhost usr")]
        public void GivenNavigateToLocalhostUsr()
        {
            driver.Navigate().GoToUrl("http://localhost:3252/");

            Thread.Sleep(mil);
        }
        
        [When(@"Enter Code usr")]
        public void WhenEnterCodeUsr()
        {
            driver.FindElement(By.Id("user")).SendKeys("2626");

            Thread.Sleep(mil);
        }
        
        [When(@"enter password usr")]
        public void WhenEnterPasswordUsr()
        {
            driver.FindElement(By.Id("password")).SendKeys("2626");

            Thread.Sleep(mil);
        }
        
        [When(@"Click on Login Button usr")]
        public void WhenClickOnLoginButtonUsr()
        {
            driver.FindElement(By.Id("btn")).Click();

            Thread.Sleep(mil);
        }
        
        [When(@"Click on Usuario Button\tusr")]
        public void WhenClickOnUsuarioButtonUsr()
        {
            driver.FindElement(By.Id("usuarios")).Click();
            Thread.Sleep(mil);
        }
        
        [When(@"Click on Agregar Button usr")]
        public void WhenClickOnAgregarButtonUsr()
        {
            driver.FindElement(By.Id("agregar")).Click();
            Thread.Sleep(mil);
        }
        
        [When(@"fill form new usr usr")]
        public void WhenFillFormNewUsrUsr()
        {
            driver.FindElement(By.Id("apellido")).SendKeys("PruebaBDD");
            driver.FindElement(By.Id("codUsuario")).SendKeys("2626");
            driver.FindElement(By.Id("password")).SendKeys("Sergio1!");
            driver.FindElement(By.Id("dpi")).SendKeys("2422927120101");
            Thread.Sleep(mil);
        }
        
        [When(@"Click on create Button usr")]
        public void WhenClickOnCreateButtonUsr()
        {
            driver.FindElement(By.Id("btn")).Click();

            Thread.Sleep(mil);
        }
        
        [When(@"fill form new usr usr without DPI")]
        public void WhenFillFormNewUsrUsrWithoutDPI()
        {
            driver.FindElement(By.Id("apellido")).SendKeys("PruebaBDD");
            driver.FindElement(By.Id("codUsuario")).SendKeys("2626");
            driver.FindElement(By.Id("password")).SendKeys("Sergio1!");
            Thread.Sleep(mil);
        }
        
        [When(@"fill form new usr usr without apellido")]
        public void WhenFillFormNewUsrUsrWithoutApellido()
        {
            driver.FindElement(By.Id("codUsuario")).SendKeys("2626");
            driver.FindElement(By.Id("password")).SendKeys("Sergio1!");
            driver.FindElement(By.Id("dpi")).SendKeys("2422927120101");
            Thread.Sleep(mil);
        }
        
        [When(@"fill form new usr usr without password")]
        public void WhenFillFormNewUsrUsrWithoutPassword()
        {
            driver.FindElement(By.Id("apellido")).SendKeys("PruebaBDD");
            driver.FindElement(By.Id("codUsuario")).SendKeys("2626");
            driver.FindElement(By.Id("dpi")).SendKeys("2422927120101");
            Thread.Sleep(mil);
        }
        
        [Then(@"Result should be visible usr")]
        public void ThenResultShouldBeVisibleUsr()
        {
            driver.Quit();
        }
        
        [Then(@"Result should be visible fail message")]
        public void ThenResultShouldBeVisibleFailMessage()
        {
            driver.Quit();
        }
    }
}
