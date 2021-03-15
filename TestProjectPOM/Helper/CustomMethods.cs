using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectPOM.Helper
{
    public class CustomMethods: Base
    {
        public void ImplicitWait(int sec)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
        }

        public WebDriverWait ExplicitWait(IWebElement element, string locator, PropertyType elementType)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            if(elementType == PropertyType.Id)
                wait.Until(x => x.FindElement(By.Id(locator)));
            if(elementType == PropertyType.Name)
                wait.Until(x => x.FindElement(By.Name(locator)));
            if (elementType == PropertyType.XPath)
                wait.Until(x => x.FindElement(By.XPath(locator)));
            return wait;
        }

        public DefaultWait<IWebElement> defaultwait(IWebElement element, string locator, PropertyType elementType)
        {
            var  wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(250),
                Message = "No such element"
            };
            if (elementType == PropertyType.Id)
                wait.Until(x => x.FindElement(By.Id(locator)));
            switch (elementType)
            {
                case PropertyType.Id:
                    wait.Until(x => x.FindElement(By.Id(locator)));
                    break;
                case PropertyType.Name:
                    wait.Until(x => x.FindElement(By.Name(locator)));
                    break;
                case PropertyType.XPath:
                    wait.Until(x => x.FindElement(By.XPath(locator)));
                    break;
                default:
                    break;
            }
            return wait;
        }

        public WebDriverWait waitForElementBy(IWebElement element, string locator, PropertyType elementType)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromMilliseconds(250),
                Message = "No such element"
            };
            Func<IWebDriver, bool> waitfor = new Func<IWebDriver, bool>((driver) =>
            {
                if (elementType == PropertyType.Id)
                    wait.Until(x => x.FindElement(By.Id(locator)));
                return true;
            });
            return wait;
        }

        public void SetTextToElement(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public void ClickElements(IList<IWebElement> element, int index)
        {
            element[index].Click();
        }

        public void SelectElement(IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }
    }

    public enum PropertyType
    {
        Id,
        Name,
        XPath
    }
}
