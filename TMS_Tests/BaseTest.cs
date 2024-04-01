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
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void Setup()
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
        }
    }
}