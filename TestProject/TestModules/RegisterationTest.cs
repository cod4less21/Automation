using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Pages;

namespace TestProject.TestModules
{
    public class RegisterationTest:Base
    {
        RegistrationPage registrationPage;
        public RegisterationTest()
        {
            this.registrationPage = new RegistrationPage();
        }

        [Test]
        public void NewUser()
        {
            registrationPage.ClickRegister();
            registrationPage.SetUserName();
            registrationPage.SetPassword();
            registrationPage.SetConfirmPassword();
            registrationPage.SetEmail();
            registrationPage.ClickSubmitBtn();
            
            Assert.IsTrue(registrationPage.IsLoginTextDisplayed()
                .Contains(RegistrationDetails.UserName));
        }
    }
}
