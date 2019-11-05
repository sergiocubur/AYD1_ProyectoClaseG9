using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
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
                
        [When(@"Enter error code user (.*)")]
        public void WhenEnterErrorCodeUser(int p0)
        {
            driver.FindElement(By.Id("user")).SendKeys("2627");

            Thread.Sleep(mil);
        }
        
        [When(@"enter error Password (.*)")]
        public void WhenEnterErrorPassword(int p0)
        {
            driver.FindElement(By.Id("password")).SendKeys("2627");

            Thread.Sleep(mil);
        }
        
        [When(@"Enter error code user null")]
        public void WhenEnterErrorCodeUserNull()
        {
            Thread.Sleep(mil);

        }
        
        [When(@"enter error Password null")]
        public void WhenEnterErrorPasswordNull()
        {
            Thread.Sleep(mil);

        }
        
        [When(@"Click on Login Button to fail")]
        public void WhenClickOnLoginButtonToFail()
        {
            driver.FindElement(By.Id("btn")).Click();

            Thread.Sleep(mil);
        }

        [When(@"Navigate to root page")]
        public void Navigatetorootpage()
        {
            driver.Navigate().GoToUrl("http://localhost:3252/");

            Thread.Sleep(mil);
        }

        [Then(@"Result should be visible home")]
        public void Resultshouldbevisiblehome()
        {
            Thread.Sleep(mil);
            driver.Quit();
        }


        [Then(@"Result should be visible login fail mesage")]
        public void ThenResultShouldBeVisibleLoginFailMesage()
        {
            Thread.Sleep(mil);
            driver.Quit();
        }
    }
}
