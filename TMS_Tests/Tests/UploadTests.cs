using OpenQA.Selenium;
using System.Reflection;

namespace TMS_Tests.Tests
{
    public class UploadTests : BaseTest
    {
        [SetUp]
        public void OpenSite()
        {
            Driver.Navigate().GoToUrl("https://formy-project.herokuapp.com/fileupload");
        }

        [Test]
        public void UploadFile()
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources",
            "TextFile1.txt");
            Driver.FindElement(By.Id("file-upload-field")).SendKeys(filePath);
            Driver.FindElement(By.XPath("//*[.='Reset']")).Click();
        }
    }
}
