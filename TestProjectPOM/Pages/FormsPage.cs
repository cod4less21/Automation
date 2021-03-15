using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace TestProjectPOM.Pages
{
    public class FormsPage: Base
    {
        private IWebElement PracticeForm(string text) => driver.FindElement(By.XPath("//span[text()='"+text+"']"));
        private IList<IWebElement> MyFormElements => driver.FindElements(By.XPath($"//input[@type='text']"));
        private IList<IWebElement> mycheckbox => driver.FindElements(By.XPath("//div[@class='custom-control custom-checkbox custom-control-inline']"));
        private IWebElement selectGender(string gender) => driver.FindElement(By.XPath($"//label[text()='{gender}']"));
        private IWebElement uploadImg => driver.FindElement(By.Id("uploadPicture"));
        private IWebElement currentAddress => driver.FindElement(By.Id("currentAddress"));
        private IWebElement selectDate => driver.FindElement(
            By.XPath("//div[@class='react-datepicker__day react-datepicker__day--015']"));
        private IList<IWebElement> seletElement => driver.FindElements(By.XPath("//div[@class=' css-1hwfws3']"));


        public void ClickPracticeForm(string txt) => PracticeForm(txt).Click();
        public void SetTextToFirstName(string firtName) => MyFormElements[0].SendKeys(firtName);
        public void SetTextToLastName(string LastName) => MyFormElements[1].SendKeys(LastName);
        public void SetTextToEmail(string email) => MyFormElements[2].SendKeys(email);
        public void SetTextToMobileNumber(string mobile) => MyFormElements[3].SendKeys(mobile);
        public void SetTextToDOB()
        {
            MyFormElements[4].Click();
            MyFormElements[4].Clear();
            selectDate.Click();
        }
        public void clickSports() => mycheckbox[0].Click();
        public void clickReading() => mycheckbox[1].Click();
        public void clickMusic() => mycheckbox[2].Click();
        public void Gender(string gender) => selectGender(gender).Click();
        public void AddImg() => uploadImg.SendKeys("C:\\Users\\joseph.ekeleme\\Desktop\\MyFolder\\update laptop.jpg");
        public void AddImg2() => uploadImg.SendKeys(@"C:\Users\joseph.ekeleme\Desktop\MyFolder\update laptop.jpg");
        public void SetCurrentAddress(string address) => currentAddress.SendKeys(address);
        public void SelectState()
        {           
            Actions action = new Actions(Base.driver);
            action.Click(seletElement[0]).SendKeys(Keys.ArrowDown)
                .SendKeys(Keys.Enter)
                .Build().Perform();
        }
        public void SelectCity()
        {
            Actions action = new Actions(Base.driver);
            action.Click(seletElement[1]).SendKeys(Keys.ArrowDown)
                .SendKeys(Keys.Enter)
                .Build().Perform();
        }
    }
}
