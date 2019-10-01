using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Inventario.Tests
{
    [Binding]
    public class SearchSteps
    {
        public IWebDriver driver;
        [Given(@"Lunch Chrome")]
        public void GivenLunchChrome()
        {
            //lauch brouser
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"E:\", "chromedriver.exe");
            driver = new ChromeDriver(service);

            //navigate to URL https://www.codeproject.com
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            
        }
        
        [Given(@"Navigate to code Project")]
        public void GivenNavigateToCodeProject()
        {
            driver.Navigate().GoToUrl("https://www.codeproject.com");
        }
        
        [When(@"Click on Search our Articles")]
        public void WhenClickOnSearchOurArticles()
        {
            //Click search our article
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentPane']/div[1]/div/table[1]/tbody/tr/td[3]/a/img")).Click();
        }
        
        [When(@"Enter Testing")]
        public void WhenEnterTesting()
        {
            //enter testing
            driver.FindElement(By.Id("ctl00_MC_Query")).SendKeys("Testing");
        }
        
        [When(@"Click on Search Button")]
        public void WhenClickOnSearchButton()
        {
            //click on search button
            driver.FindElement(By.Id("ctl00_MC_Go")).Click();
        }
        
        [Then(@"Result should be visible and Browser should close")]
        public void ThenResultShouldBeVisibleAndBrowserShouldClose()
        {
            driver.Quit();
        }
    }
}
