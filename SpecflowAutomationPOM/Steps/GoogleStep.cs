using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SpecflowAutomationPOM.Steps
{
    [Binding]
    public sealed class GoogleStep
    {
        private readonly ScenarioContext _scenarioContext;
        string url = "https://www.google.com/";
        IWebDriver driver;

        public GoogleStep(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on google page")]
        public void GivenIAmOnGooglePage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I click (.*) button")]
        public void GivenIClickIAgreeButton(string buttonName)
        {
            driver.SwitchTo().Frame(0);
            driver.FindElement(By.Id("introAgreeButton")).Click();
        }

        [When(@"I enter '(.*)' in the search box")]
        public void WhenIEnterAutomationInTheSearchBox(string searchTxt)
        {
            var s = driver.FindElement(By.Name("q"));
            s.SendKeys(searchTxt);
            s.Submit();
        }


        [Then(@"I should see my search result '(.*)'")]
        public void ThenIShouldSeeMySearchResultAutomation(string searchTxt)
        {
            var Actualresult = 
                driver.FindElement(By.XPath("//span[text()='Automation']")).Text;
            Assert.AreEqual(searchTxt, Actualresult,
                $"{searchTxt} is not displayed");
        }

    }
}
