using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
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
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        [OneTimeSetUp]
        [AllureBefore("Clean up allure-results directory")]
        public static void GlobalSetup()
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
        [AllureAfter("Driver quit")]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot= ((ITakesScreenshot)Driver).GetScreenshot();
                var screenshotByte = screenshot.AsByteArray;
                AllureApi.AddAttachment("screenshot", "image/png", screenshotByte);
            }
            Driver.Quit();
        }
    }
}
