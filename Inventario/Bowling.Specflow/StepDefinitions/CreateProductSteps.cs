using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Bowling.Specflow.StepDefinitions
{
    [Binding]
    public class CreateProductSteps
    {
        public IWebDriver driver;
        public int mil = 2000;

        [Given(@"Lunch navigator Chrome pro")]
        public void GivenLunchNavigatorChromePro()
        {
            //lauch brouser
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"E:\", "chromedriver.exe");
            driver = new ChromeDriver(service);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
        }
        
        [Given(@"Navigate to localhost pro")]
        public void GivenNavigateToLocalhostPro()
        {
            driver.Navigate().GoToUrl("http://localhost:3252/");

            Thread.Sleep(mil);
        }
        
        [When(@"Enter Code pro")]
        public void WhenEnterCodePro()
        {
            driver.FindElement(By.Id("user")).SendKeys("2626");

            Thread.Sleep(mil);
        }
        
        [When(@"enter password pro")]
        public void WhenEnterPasswordPro()
        {
            driver.FindElement(By.Id("password")).SendKeys("2626");

            Thread.Sleep(mil);
        }
        
        [When(@"Click on Login Button pro")]
        public void WhenClickOnLoginButtonPro()
        {
            driver.FindElement(By.Id("btn")).Click();

            Thread.Sleep(mil);
        }
        
        [When(@"Click on Product Button\tpro")]
        public void WhenClickOnProductButtonPro()
        {
            driver.FindElement(By.Id("productos")).Click();
            Thread.Sleep(mil);
        }
        
        [When(@"Click on Agregar Button pro")]
        public void WhenClickOnAgregarButtonPro()
        {
            driver.FindElement(By.Id("agregar")).Click();
            Thread.Sleep(mil);

        }

        [When(@"fill form new product\tpro")]
        public void WhenFillFormNewProductPro()
        {
            driver.FindElement(By.Id("idproducto")).SendKeys("999");
            driver.FindElement(By.Id("descripcion")).SendKeys("Prod1");
            driver.FindElement(By.Id("precio_compra")).SendKeys("100.0");
            driver.FindElement(By.Id("precio_venta")).SendKeys("100.0");
            Thread.Sleep(mil);
        }       
        
        
        [When(@"fill form new product\twithout description pro")]
        public void WhenFillFormNewProductWithoutDescriptionPro()
        {
            driver.FindElement(By.Id("idproducto")).SendKeys("999");
            driver.FindElement(By.Id("precio_compra")).SendKeys("100.0");
            driver.FindElement(By.Id("precio_venta")).SendKeys("100.0");
            Thread.Sleep(mil);
        }
        
        [When(@"Click on create Button pro")]
        public void WhenClickOnCreateButtonPro()
        {
            driver.FindElement(By.Id("btn")).Click();

            Thread.Sleep(mil);
        }
        
        [When(@"fill form new product whitout prices pro")]
        public void WhenFillFormNewProductWhitoutPricesPro()
        {
            driver.FindElement(By.Id("idproducto")).SendKeys("998");
            driver.FindElement(By.Id("descripcion")).SendKeys("Prod1");
            Thread.Sleep(mil);
        }
        
        [When(@"fill form new product\twithout code pro")]
        public void WhenFillFormNewProductWithoutCodePro()
        {
            driver.FindElement(By.Id("descripcion")).SendKeys("Prod1");
            driver.FindElement(By.Id("precio_compra")).SendKeys("100.0");
            driver.FindElement(By.Id("precio_venta")).SendKeys("100.0");
            Thread.Sleep(mil);
        }
        
        [Then(@"Result should be visible pro")]
        public void ThenResultShouldBeVisiblePro()
        {
            driver.Quit();
        }
        
        [Then(@"Result should be visible fail")]
        public void ThenResultShouldBeVisibleFail()
        {
            driver.Quit();
        }
        
        [Then(@"Result should be visible fail pro")]
        public void ThenResultShouldBeVisibleFailPro()
        {
            driver.Quit();
        }
    }
}
