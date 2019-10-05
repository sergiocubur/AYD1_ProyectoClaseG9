using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Inventario.Tests
{
    class Class1
    {
        [Test]
        public void Search_Test() {
            //lauch brouser
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"E:\", "chromedriver.exe");
            IWebDriver driver = new ChromeDriver(service);

            //navigate to URL https://www.codeproject.com
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            driver.Navigate().GoToUrl("https://www.codeproject.com");

            //Click search our article
            driver.FindElement(By.XPath("//*[@id='ctl00_ContentPane']/div[1]/div/table[1]/tbody/tr/td[3]/a/img")).Click();
            //enter testing
            driver.FindElement(By.Id("ctl00_MC_Query")).SendKeys("Testing");

            //click on search button
            driver.FindElement(By.Id("ctl00_MC_Go")).Click();

            driver.Quit();
        }
    }
}
