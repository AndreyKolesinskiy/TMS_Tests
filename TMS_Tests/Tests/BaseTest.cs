﻿using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Reflection;
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
        //[OneTimeSetUp]
        //[AllureBefore("Clean up allure-results directory")]
        //public static void GlobalSetup()
        //{
        //    AllureLifecycle.Instance.CleanupResultDirectory();
        //}

        protected Logger logger = LogManager.GetCurrentClassLogger();
        public IWebDriver Driver { get; set; }
        public LoginPage LoginPage { get; set; }
        public ProductsPage ProductsPage { get; set; }
        public YourCartPage YourCartPage { get; set; }
        public WaitsHelper? WaitsHelper { get; set; }
        public Actions Actions { get; set; }
        public TRLoginPage TRLoginPage { get; set; }
        public TRDashboardPage TRDashboardPage { get; set; }
        public TRAddProjectPage TRAddProjectPage { get; set; }
        public TRProjectsPage TRProjectsPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            Driver = new Browser().Driver;
            LoginPage = new LoginPage(Driver);
            ProductsPage = new ProductsPage(Driver);
            YourCartPage = new YourCartPage(Driver);
            WaitsHelper = new WaitsHelper(Driver);
            Actions = new Actions(Driver);
            TRLoginPage = new TRLoginPage(Driver);
            TRDashboardPage = new TRDashboardPage(Driver);
            TRAddProjectPage = new TRAddProjectPage(Driver);
            TRProjectsPage = new TRProjectsPage(Driver);
        }

        [TearDown]
        [AllureAfter("Driver quit")]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var screenshotByte = screenshot.AsByteArray;
                AllureApi.AddAttachment("screenshot", "image/png", screenshotByte);
            }
            try
            {
                var errorLogfilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "ErrorLogFile.txt");
                var infoLogfilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "InfoLogFile.txt");

                AllureApi.AddAttachment("errorLog", "text/html", errorLogfilePath);
                AllureApi.AddAttachment("infoLog", "text/html", infoLogfilePath);
            }
            catch
            {
                Console.WriteLine("Couldnt load file");
            }
            Driver.Close();
            Driver.Quit();
            
        }
    }
}
