using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace WebDriverTutorial.StepDefinitions
{
    [Binding]
    public class SearchSteps
    {
        IWebDriver driver = new ChromeDriver();
        [Given(@"that user is on amazon webpage")]
        public void GivenThatUserIsOnAmazonWebpage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.in");
        }
        
        [Given(@"user is able to navigate to searhbox")]
        public void GivenUserIsAbleToNavigateToSearhbox()
        {
            IWebElement element = driver.FindElement(By.Id("twotabsearchtextbox"));
        }

        [Then(@"user is searching '(.*)'")]
        public void ThenUserIsSearching(string dev)
        {
            IWebElement element = driver.FindElement(By.Id("twotabsearchtextbox"));
            element.SendKeys(dev);
            element.Submit();
        }

    }
}
