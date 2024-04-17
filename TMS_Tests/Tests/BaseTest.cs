using Allure.Net.Commons;
using Allure.NUnit;
using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TMS_Tests.Core;
using TMS_Tests.Pages;
using TMS_Tests.Utils;

namespace TMS_Tests.Tests
{
    //[Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [TestFixture]
    public class BaseTest
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        public IWebDriver Driver { get; set; }
        public LoginPage LoginPage { get; set; }
        public ProductsPage ProductsPage { get; set; }
        public YourCartPage YourCartPage { get; set; }
        public WaitsHelper? WaitsHelper { get; set; }
        public Actions Actions { get; set; }

        [SetUp]
        public void SetUp()
        {
            Driver = new Browser().Driver;
            LoginPage = new LoginPage(Driver);
            ProductsPage = new ProductsPage(Driver);
            YourCartPage = new YourCartPage(Driver);
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut));
            Actions = new Actions(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
