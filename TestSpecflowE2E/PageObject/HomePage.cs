using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestSpecflowE2E.PageObject
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTourl() => driver.Navigate().GoToUrl("http://www.google.com");
    }
}
