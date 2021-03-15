using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectPOM.Pages
{
    public class AlertFrameWindowsPage: Base
    {
        private IWebElement browseWindowsMenu => 
            driver.FindElement(By.XPath("//li[@id='item-0']//span[text()='Browser Windows']"));

        private IWebElement AlertsMenu => 
            driver.FindElement(By.XPath("//li[@id='item-1']//span[text()='Alerts']"));

        private IWebElement newTabWindow => driver.FindElement(By.Id("tabButton"));

        private IWebElement newTabWindowText => driver.FindElement(By.Id("sampleHeading"));

        private IWebElement clickMeAlertButton => driver.FindElement(By.Id("alertButton"));

        

        

        public void ClickBrowWindowMenu() => browseWindowsMenu.Click();
        public void ClickAlertsWindowsMenu() => AlertsMenu.Click();
        public void ClicknewTabWindow() => newTabWindow.Click();
        public bool IsNewTabWindowTextDisplayed() => newTabWindowText.Displayed;
        public string IsNewTabWindowTextDisplayed2() => newTabWindowText.Text;
        public void ClickMealertButton() => clickMeAlertButton.Click();

    }
}
