using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestProjectPOM.Pages
{
    public class HomePage: Base
    {
        //private IWebElement Element(int index) => driver.FindElement(By.XPath($"(//div[@class='card mt-4 top-card'])[{index}]"));
        private IWebElement Element => driver.FindElement(By.XPath($"(//div[@class='card mt-4 top-card'])[1]"));
        private IWebElement Forms => driver.FindElement(By.XPath($"(//div[@class='card mt-4 top-card'])[2]"));
        private IWebElement AlertFrameWindows => driver.FindElement(By.XPath("(//div[@class='card mt-4 top-card'])[3]"));
        private IWebElement Widgets => driver.FindElement(By.XPath("(//div[@class='card mt-4 top-card'])[4]"));
        private IWebElement Interactions => driver.FindElement(By.XPath("(//div[@class='card mt-4 top-card'])[5]"));
        private IWebElement BookStoreapplication => driver.FindElement(By.XPath("(//div[@class='card mt-4 top-card'])[6]"));
        private IWebElement myelement(string index) => driver.FindElement(By.XPath($"(//div[@class='card mt-4 top-card'])[{index}]"));

        public void Initialise()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            option.AddArgument("--headless");
            driver = new ChromeDriver(option);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        //public void ClickElements(int index) => Element(index).Click();
        public void ClickElements() => Element.Click();
        public string GetPageTitle() => driver.Title;
        public void NavigateToSite() => driver.Navigate().GoToUrl("https://demoqa.com/");
        public void ClickForms(int index) => Forms.Click();
        public void ClickAlertFrameWindows() => AlertFrameWindows.Click();
        public void ClickWidgets() => Widgets.Click();
        public void ClickInteractions() => Interactions.Click();
        public void ClickBookStoreapplication() => BookStoreapplication.Click();
        public void CloseBrowser() => driver.Quit();
        public string GetText(string index) => myelement(index).Text;
        public bool IsElementsDisplayed(string index) => myelement(index).Displayed;
        public void TakeScreenImage(string name)
        {
            ((ITakesScreenshot)Base.driver).GetScreenshot().SaveAsFile(
                $"C:\\Users\\joseph.ekeleme\\source\\repos\\TestProjectPOM2\\TestProjectPOM2\\ScreenShots\\{name}", 
                ScreenshotImageFormat.Jpeg);
        }

    }
}
