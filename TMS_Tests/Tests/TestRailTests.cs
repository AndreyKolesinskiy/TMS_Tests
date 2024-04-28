using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TMS_Tests.Element;

namespace TMS_Tests.Tests
{
    [TestFixture]
    public class TestRailTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            //TRLoginPage.SuccessfulLogin();
        }

        [Test]
        public void CreateTestProject()
        {
            Driver.Navigate().GoToUrl("https://qac0402.testrail.io/");
            UiElement EmailField = new(Driver, By.Id("name"));
            EmailField.Click();
        }
    }
}


