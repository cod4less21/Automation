using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowAutomationPOM.CustomeMethods
{
    class CustomeMethodHelpers
    {
        public void WaitForElementBy(string by, string element, IWebDriver Driver)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.IgnoreExceptionTypes(typeof(InvalidOperationException));

            wait.Until(x => 
            {
                try
                {
                    IWebElement Webelement = @by switch
                    {
                        "Id" => x.FindElement(By.Id(element)),
                        "Name" => x.FindElement(By.Name(element)),
                        "Xpath" => x.FindElement(By.XPath(element)),
                        _ => throw new NoSuchElementException(),
                    };
                }
                catch (Exception) { }
                return wait;
            });
        }
    }

    static class CustomeStaticMethod
    {
        public static void WaitForElementBy(this IWebElement Webelement, string by, string element, IWebDriver Driver)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.IgnoreExceptionTypes(typeof(InvalidOperationException));

            wait.Until(x =>
            {
                try
                {
                    Webelement = @by switch
                    {
                        "Id" => x.FindElement(By.Id(element)),
                        "Name" => x.FindElement(By.Name(element)),
                        "Xpath" => x.FindElement(By.XPath(element)),
                        _ => throw new NoSuchElementException(),
                    };
                }
                catch (Exception) { }
                return wait;
            });
        }

        public static void WaitForElementBy2(this IWebElement Webelement, 
            string by, string element, IWebDriver Driver)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.IgnoreExceptionTypes(typeof(InvalidOperationException));

            wait.Until(x =>
            {
                try
                {
                    Webelement = @by switch
                    {
                        "Id" => x.FindElement(By.Id(element)),
                        "Name" => x.FindElement(By.Name(element)),
                        "Xpath" => x.FindElement(By.XPath(element)),
                        _ => throw new NoSuchElementException(),
                    };
                }
                catch (Exception) { }
                return wait;
            });
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int time)
        {
            if (time > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10));
                return wait.Until(x=>x.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static IReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int time)
        {
            if (time > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10));
                return wait.Until(x => x.FindElements(by).Count > 0) ? driver.FindElements(by) : null;
            }
            return driver.FindElements(by);
        }

    }
}
