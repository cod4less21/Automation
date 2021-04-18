using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestSpecflowE2EPOM.PageObjects
{
    public class ElementsPage
    {
        IWebDriver driver;
        public ElementsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement TextBox(string elementAlias) => 
            driver.FindElement(By.XPath($"//li[@id='item-0'][.='{elementAlias}']"));

        private IWebElement FullNameField =>
            driver.FindElement(By.Id("userName"));

        private IWebElement EmailField => driver.FindElement(By.Id("userEmail"));

        public void ClickTextBox(string elemetAlias) => TextBox(elemetAlias).Click();

        public void EnterFullName(string fullName) => FullNameField.SendKeys(fullName);

        public void EnterEmail(string email) => EmailField.SendKeys(email);

        public string GetFullNameText() => FullNameField.GetAttribute("value");
    }
}
