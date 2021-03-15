using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace TestProjectPOM.Pages
{
    public class ElemetsPage:Base
    {
        private ReadOnlyCollection<IWebElement> elements => driver.FindElements(By.XPath("//*[@class='btn btn-light ']"));

        public void ClickTextBox()
        {
            foreach (var element in elements)
            {
                if (element.Text == "Text Box")
                {
                    element.Click();
                    break;
                }
            }
        }

        public void ClickCheckBox() => elements[1].Click();
    
    }
}
