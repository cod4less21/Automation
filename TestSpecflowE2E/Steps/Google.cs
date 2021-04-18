using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestSpecflowE2E.PageObject;

namespace TestSpecflowE2E.Steps
{
    [Binding]
    public class Google
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver driver;
        readonly HomePage homePage;

        public Google(IObjectContainer objectContainer)
        {
            this._scenarioContext = objectContainer.Resolve<ScenarioContext>();
            this.driver = objectContainer.Resolve<IWebDriver>();
            this.homePage = objectContainer.Resolve<HomePage>();
        }

        [Given(@"I am on google page")]
        public void GivenIAmOnGooglePage()
        {
            homePage.NavigateTourl();
        }

    }
}
