using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace WebDriverTutorial.StepDefinitions
{
    [Binding]
    public class ProductSteps
    {
        IWebDriver driver = new ChromeDriver();
        [Given(@"user is able to navigate to google")]
        public void GivenUserIsAbleToNavigateToGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }
        
        [Then(@"user is able to search (.*)")]
        public void ThenUserIsAbleToSearchIPad(string device)
        {
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys(device);
            element.Submit();
        }
    }
}
