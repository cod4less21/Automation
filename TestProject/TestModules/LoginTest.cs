using NUnit.Framework;
using OpenQA.Selenium;

namespace TestProject
{
    public class LoginTest: Base
    {
        [Test]
        public void PositiveLoginTest()
        {
            Driver.FindElement(By.LinkText("Login")).Click();

            Driver.FindElement(By.Id("UserName"))
                .SendKeys(RegistrationDetails.UserName);
            var passWord = Driver.FindElement(By.Id("Password"));
                passWord.SendKeys(RegistrationDetails.Password);
            passWord.Submit();

            var LoginDetails = Driver.FindElement(By.XPath("//a[@title='Manage']"));
            Assert.IsTrue(LoginDetails.Text.Contains(RegistrationDetails.UserName));

            Assert.IsTrue(Driver.FindElement(By.XPath("//a[@title='Manage']"))
                .Text.Contains(RegistrationDetails.UserName));

            var LogOffText = Driver.FindElement(By.XPath("//a[text()='Log off']"));
            var DisplayeText = LogOffText.Text;

            if (DisplayeText.Equals("Log off"))
            {
                Assert.IsTrue(DisplayeText.Equals("Log off"));
            }
            else
            {
                throw new System.Exception();
            }

            var DisplayedUsernameText =
                LoginDetails.Text.Equals("Hello" + " " + RegistrationDetails.UserName + "!");

            var DisplayedUsernameText2 =
                LoginDetails.Text.Equals($"Hello{" "}{RegistrationDetails.UserName}{"!"}");

            Assert.IsTrue(
                LoginDetails.Text.Equals("Hello" + " " + RegistrationDetails.UserName + "!"));
        }

        [Test]
        public void NegativeLoginTest()
        {
            Driver.FindElement(By.LinkText("Login")).Click();
        }
    }
}
