using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectPOM.Pages
{
    public class BookStoreApplicationPage: Base
    {
        private IWebElement LoginMenu => 
            driver.FindElement(By.XPath("//li[@id='item-0']//span[.='Login']"));

        private IWebElement UserName => driver.FindElement(By.Id("userName"));

        private IWebElement Password => driver.FindElement(By.Id("password"));

        

        public void ClickLoginMenu() => LoginMenu.Click();
        public void SetTextToUserName(string username) => UserName.SendKeys(username);
        public void SetTextToPassword(string password) => Password.SendKeys(password);
    }
}
