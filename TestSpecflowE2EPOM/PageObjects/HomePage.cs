using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestSpecflowE2EPOM.PageObjects
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Elements(string elementAlias) =>
            driver.FindElement(By.XPath($"//div[@class='card mt-4 top-card'][.='{elementAlias}']"));



        public void ClickElements(string elemetsAlias) => Elements(elemetsAlias).Click();

        public bool IsElementsDisplayed(string elementAlias) => Elements(elementAlias).Displayed;
    }
}
