using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Bowling.Specflow.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver driver;
        public int mil = 2000;

        [Given(@"Lunch navigator Chrome")]
        public void GivenLunchNavigatorChrome()
        {
            //lauch brouser
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"E:\", "chromedriver.exe");
            driver = new ChromeDriver(service);

            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
        }
        
        [Given(@"Navigate to localhost")]
        public void GivenNavigateToLocalhost()
        {

            driver.Navigate().GoToUrl("http://localhost:3252/");
            
            Thread.Sleep(mil);
        }
        
        [When(@"Enter code user (.*)")]
        public void WhenEnterCodeUser(int p0)
        {
            driver.FindElement(By.Id("user")).SendKeys("2626");
            
            Thread.Sleep(mil);
        }
        
        [When(@"enter Password (.*)")]
        public void WhenEnterPassword(int p0)
        {
            driver.FindElement(By.Id("password")).SendKeys("2626");
            
            Thread.Sleep(mil);
        }
        
        [When(@"Click on Login Button")]
        public void WhenClickOnLoginButton()
        {
            driver.FindElement(By.Id("btn")).Click();
            
            Thread.Sleep(mil);
        }
        
        [Then(@"Result should be visible home page")]
        public void ThenResultShouldBeVisibleHomePage()
        {
            driver.Quit();
        }
    }
}
