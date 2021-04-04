using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Pages
{
    public class RegistrationPage: Base
    {
        private IWebElement Register => 
            Driver.FindElement(By.LinkText("Register"));
        private IWebElement UserName => 
            Driver.FindElement(By.Id("UserName"));
        private IWebElement Password => 
            Driver.FindElement(By.Id("Password"));
        private IWebElement ConfirmPassword => 
            Driver.FindElement(By.Id("ConfirmPassword"));
        private IWebElement Email => Driver.FindElement(By.Id("Email"));
        private IWebElement Submitbtn => 
            Driver.FindElement(By.XPath("//*[@type='submit']"));
        private IWebElement LoginTextManager => 
            Driver.FindElement(By.XPath("//a[@title='Manage']"));


        public void ClickRegister() => Register.Click();
        public void SetUserName() => UserName.SendKeys(RegistrationDetails.UserName);
        public void SetPassword() => Password.SendKeys(RegistrationDetails.Password);
        public void SetConfirmPassword() => 
            ConfirmPassword.SendKeys(RegistrationDetails.ConfirmPassword);
        public void SetEmail() => Email.SendKeys(RegistrationDetails.Email);
        public void ClickSubmitBtn() => Email.Click();
        public string IsLoginTextDisplayed() => LoginTextManager.Text;
    }
}
