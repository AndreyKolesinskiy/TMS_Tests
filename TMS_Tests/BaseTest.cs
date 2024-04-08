using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Tests
{
    internal class BaseTest
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void OneTimeSetup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }
    }
}
