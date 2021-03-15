using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using TestProjectPOM.Helper;
using TestProjectPOM.Pages;

namespace TestProjectPOM
{
    [TestFixture]
    public class TestClass
    {
        HomePage homePage;
        ElemetsPage ElemetsPage;
        FormsPage formsPage;
        CustomMethods customMethods;
        AlertFrameWindowsPage alertFrameWindowsPage;
        BookStoreApplicationPage BookStoreApplicationPage;

        public TestClass()
        {
            this.homePage = new HomePage();
            this.ElemetsPage = new ElemetsPage();
            this.formsPage = new FormsPage();
            this.customMethods = new CustomMethods();
            this.alertFrameWindowsPage = new AlertFrameWindowsPage();
            this.BookStoreApplicationPage = new BookStoreApplicationPage();
        }

        [Test]
        public void ElementsTest()
        {
            homePage.Initialise();
            homePage.NavigateToSite();
            Console.WriteLine(homePage.GetPageTitle());
            //homePage.ClickElements(1);
            Console.WriteLine(homePage.GetPageTitle());
            ElemetsPage.ClickTextBox();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("ToolsQA", homePage.GetPageTitle(), "Title not equal");
                Assert.IsTrue(homePage.GetPageTitle().Equals("ToolsQA"), "Title not equal");
            });
            homePage.CloseBrowser();
        }

        [Test]
        public void FormsTest()
        {
            homePage.Initialise();
            homePage.NavigateToSite();
            int index = 2;
            homePage.ClickForms(index);
            homePage.CloseBrowser();
        }

        [Test]
        public void AlertFrameWindowsTest()
        {
            homePage.Initialise();
            homePage.NavigateToSite();
            homePage.ClickAlertFrameWindows();
            homePage.CloseBrowser();
        }

        [Test]
        public void WidgetTest()
        {
            homePage.Initialise();
            homePage.NavigateToSite();
            homePage.ClickWidgets();
            homePage.CloseBrowser();
        }

        [Test]
        public void ParamTest()
        {
            homePage.Initialise();
            homePage.NavigateToSite();
            Console.WriteLine(homePage.IsElementsDisplayed(utilities.Elements));
            Thread.Sleep(3000);
            homePage.CloseBrowser();
        }

        [Test]
        public void FillForm()
        {
            homePage.Initialise();
            homePage.NavigateToSite();
            homePage.ClickForms(1);
            customMethods.ImplicitWait(2);
            IWebElement p(string text) => Base.driver.FindElement(By.XPath("//span[text()='" + text + "']"));
            customMethods.ExplicitWait(p("Practice Form"), "//span[text()='Practice Form']", PropertyType.XPath);
            formsPage.ClickPracticeForm("Practice Form");
            formsPage.SetTextToFirstName("Odun");
            formsPage.SetTextToLastName("MajorGeneral");
            formsPage.SetTextToEmail("abc@abc.com");
            formsPage.Gender("Male");
            formsPage.SetTextToMobileNumber("00009877666");
            formsPage.SetTextToDOB();
            formsPage.clickSports();
            formsPage.AddImg();
            formsPage.SetCurrentAddress(utilities.Address);
            formsPage.SelectState();
            formsPage.SelectCity();
            customMethods.ImplicitWait(3);
            homePage.CloseBrowser();
        }

        [Test]
        public void AlertTest()
        {
            homePage.Initialise();
            homePage.NavigateToSite();
            homePage.ClickAlertFrameWindows();
            alertFrameWindowsPage.ClickBrowWindowMenu();
            alertFrameWindowsPage.ClicknewTabWindow();
            Base.driver.SwitchTo().Window(Base.driver.WindowHandles[1]);
            Console.WriteLine(alertFrameWindowsPage.IsNewTabWindowTextDisplayed2());
            Assert.AreEqual("This is a sample page",
                alertFrameWindowsPage.IsNewTabWindowTextDisplayed2(),
                "Does not match");
            Assert.IsTrue(alertFrameWindowsPage.IsNewTabWindowTextDisplayed());
            Base.driver.Close();
            Base.driver.SwitchTo().Window(Base.driver.WindowHandles[0]);
            homePage.CloseBrowser();
        }

        [Test]
        public void AlertTest2()
        {
            homePage.Initialise();
            homePage.NavigateToSite();
            homePage.ClickAlertFrameWindows();
            alertFrameWindowsPage.ClickAlertsWindowsMenu();
            alertFrameWindowsPage.ClickMealertButton();
            Base.driver.SwitchTo().Alert();
            Console.WriteLine(Base.driver.SwitchTo().Alert().Text);
            Assert.AreEqual("You clicked a button", Base.driver.SwitchTo().Alert().Text);
            Base.driver.SwitchTo().Alert().Accept();
            homePage.CloseBrowser();
        }

        [Test]
        public void LoginDataDrivenTest()
        {
            homePage.Initialise();
            homePage.NavigateToSite();
            homePage.ClickBookStoreapplication();
            BookStoreApplicationPage.ClickLoginMenu();
            Thread.Sleep(2000);
            // string path = "Demo.xlsx";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string path = AppDomain.CurrentDomain.BaseDirectory + "Demo.xlsx";
            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];

                string userName = worksheet.Cells["A2"].Value.ToString();
                string password = worksheet.Cells["B2"].Value.ToString();

                BookStoreApplicationPage.SetTextToUserName(userName);
                BookStoreApplicationPage.SetTextToPassword(password);
            }

            Thread.Sleep(5000);
            homePage.CloseBrowser();
        }

        [Test]
        public void WriteDataDrivenTest()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string path = AppDomain.CurrentDomain.BaseDirectory + "Demo.xlsx";

            //var excelPackage = new ExcelPackage(new FileInfo(path));
            //var worksheet1 = excelPackage.Workbook.Worksheets.Add("Sheet2");

            //worksheet1.Cells["A1"].Value = "UserName";
            //worksheet1.Cells["B1"].Value = "FirstName";
            //worksheet1.Cells["C1"].Value = "DOB";

            //excelPackage.SaveAs(new FileInfo(path));
            //BookStoreApplicationPage.SetTextToUserName(worksheet1.Cells["A2"].Value?.ToString());

            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets
                    .FirstOrDefault(x => x.Name.Equals("Sheet1"));

                string userName = (string)(worksheet.Cells["A5"].Value
                    = utilities.UserName);
                string password = (string)(worksheet.Cells["B5"].Value
                    = utilities.Password);

                package.SaveAs(new FileInfo(path));
                Assert.AreEqual(userName, worksheet.Cells["A5"], "Not equal");
            }
        }

        [Test]
        public void ReadExcelDataViaMethod()
        {
            var reader = new ExcelReader().readExcelData("Sheet1", 1,2);
            string Result1 = reader.FirstOrDefault().GetValue(0).ToString();
            string Result2 = reader.FirstOrDefault().GetValue(1).ToString();
            Console.WriteLine(Result1);
            Console.WriteLine(Result2);

            var reader2 = new ExcelReader().readExcelData("Sheet1", 1, 2);
            string Result3 = reader2.ToList().GetRange(1, 2).ElementAtOrDefault(0).GetValue(0).ToString();
            string Result4 = reader2.ToList().GetRange(1, 2).ElementAtOrDefault(0).GetValue(1).ToString();
            Console.WriteLine(Result3);
            Console.WriteLine(Result4);


            var reader3 = new ExcelReader().readExcelData("Sheet1", 1, 2);
            string Result5 = reader3.ToList().GetRange(1, 2).ElementAtOrDefault(1).GetValue(0).ToString();
            string Result6 = reader3.ToList().GetRange(1, 2).ElementAtOrDefault(1).GetValue(1).ToString();
            Console.WriteLine(Result5);
            Console.WriteLine(Result6);
        }
    }
}
