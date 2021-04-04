using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class Base
    {
        public IWebDriver Driver { get; set; }

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--incognito");
            Driver = new ChromeDriver(options);
            Driver.Url = "http://eaapp.somee.com/";
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }


        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
