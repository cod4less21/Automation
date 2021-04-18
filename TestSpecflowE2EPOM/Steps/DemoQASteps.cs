using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestSpecflowE2EPOM.PageObjects;

namespace TestSpecflowE2EPOM.Steps
{
    [Binding]
    public sealed class DemoQASteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver driver;
        private readonly HomePage homePage;
        private readonly ElementsPage elementsPage;
        public DemoQASteps(IObjectContainer objectContainer)
        {
            this._scenarioContext = objectContainer.Resolve<ScenarioContext>();
            this.driver = objectContainer.Resolve<IWebDriver>();
            this.homePage = objectContainer.Resolve<HomePage>();
            this.elementsPage = objectContainer.Resolve<ElementsPage>();
        }

        [Given(@"I am on DemoQA page")]
        public void GivenIAmOnDemoQAPage()
        {
            driver.Navigate().GoToUrl(Paths.Url);
        }

        [Given(@"I click '(.*)'")]
        public void GivenIClick(string elementAlias)
        {
            if(homePage.IsElementsDisplayed(elementAlias))
            {
                homePage.ClickElements(elementAlias);
            }
        }

        [Given(@"I click '(.*)' on element page")]
        public void GivenIClickOnElementPage(string elementalias)
        {
            elementsPage.ClickTextBox(elementalias);
        }

        [Given(@"I wait for (.*) seconds")]
        [When(@"I wait for (.*) seconds")]
        public void GivenIWaitForSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        [When(@"I enter full Name '(.*)'")]
        public void WhenIEnterFullName(string nameAlias)
        {
            elementsPage.EnterFullName(nameAlias);
        }

        [When(@"I enter email '(.*)'")]
        public void WhenIEnterEmail(string emailAlias)
        {
            elementsPage.EnterEmail(emailAlias);
        }

        [Then(@"Full name is '(.*)'")]
        public void ThenFullNameIs(string expectedTxtAlias)
        {
            var actualFullNameText = elementsPage.GetFullNameText();
            Assert.AreEqual(expectedTxtAlias, actualFullNameText, 
                $"{expectedTxtAlias} does not match {actualFullNameText}");
        }
    }
}
