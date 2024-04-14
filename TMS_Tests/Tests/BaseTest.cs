using OpenQA.Selenium;
using TMS_Tests.Core;
using TMS_Tests.Pages;
using TMS_Tests.Utils;

namespace TMS_Tests.Tests
{
    //[Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public LoginPage LoginPage { get; set; }
        public ProductsPage ProductsPage { get; set; }
        public YourCartPage YourCartPage { get; set; }
        public WaitsHelper? WaitsHelper { get; set; }

        [SetUp]
        public void SetUp()
        {
            Driver = new Browser().Driver;
            LoginPage = new LoginPage(Driver);
            ProductsPage = new ProductsPage(Driver);
            YourCartPage = new YourCartPage(Driver);
            WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
