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
        string urlEAPage = "http://eaapp.somee.com/";
        IWebDriver driver;
        int firstNumber;
        int secondNumber;
        int ActualResult;

        public GoogleStep(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on google page")]
        public void GivenIAmOnGooglePage()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--incognito");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);
        }

        [Given(@"I click (.*) button")]
        [When(@"I click (.*) button")]
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

        [Given(@"My firstnumber is (.*)")]
        public void GivenMyFirstnumberIs(int fNumber)
        {
            //firstNumber = fNumber;
            _scenarioContext["FirstNumber"] = fNumber;
        }

        [Given(@"My second number is (.*)")]
        public void GivenMySecondNumberIs(int sNumber)
        {
            //secondNumber = sNumber;
            _scenarioContext["SecondNumber"] = sNumber;
        }

        [When(@"I add both numbers together")]
        public void WhenIAddBothNumbersTogether()
        {
            //ActualResult =  firstNumber + secondNumber;
            //var Number1 = _scenarioContext.Get<int>("FirstNumber");
            //var Number2 = _scenarioContext.Get<int>("SecondNumber");
            //ActualResult = Number1 + Number2;
            ActualResult = _scenarioContext.Get<int>("FirstNumber") + _scenarioContext.Get<int>("SecondNumber");
        }

        [Then(@"My result should be (.*)")]
        public void ThenMyResultShouldBe(int expectResult)
        {
            //Assert.AreEqual(expectResult, ActualResult);
            Assert.AreEqual(expectResult, ActualResult); 
        }

        [Given(@"I am on EA eaapp page")]
        public void GivenIAmOnEAEaappPage()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--start-maximized", "--incognito");
            //driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(urlEAPage);
        }

        [When(@"I click login link text")]
        public void WhenIClickLoginLinkText()
        {
           var Login = driver.FindElement(By.LinkText("Login"));
            Login.Click();
        }

        [When(@"I enter UserName and Password")]
        public void WhenIEnterUserNameAndPassword()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("Admin");
            var pass = driver.FindElement(By.Id("Password"));
            pass.SendKeys("Admin");
            pass.Submit();
        }

        [Then(@"Error message is displayed '(.*)'")]
        public void ThenErrorMessageIsDisplayed(string ErrorMsg)
        {
            var ErrorMessage = 
                driver.FindElement(By.XPath("//*[text()='Invalid login attempt.']"));
            var ErrortxtMessage = ErrorMessage.Text;
            var IsErrorTextMessageDisplayed = ErrorMessage.Displayed;
            Assert.IsTrue(ErrorMessage.Displayed, $"{ErrorMessage} is not displayed");
            //_scenarioContext["ErrorMsg"] = ErrortxtMessage;
            _scenarioContext.Add(ErrorMsg, ErrortxtMessage);
        }

        [Then(@"Error message '(.*)' contain '(.*)'")]
        public void ThenErrorMessageContain(string msgKey, string msg)
        {
            var Errormsg = _scenarioContext.Get<string>(msgKey);
            Assert.IsTrue(Errormsg.Contains(msg));
        }

        [Then(@"I quit my Browser")]
        public void ThenIQuitMyBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            driver = null;
        }

    }
}
