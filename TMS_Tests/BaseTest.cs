using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TMS_Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }
    }
}