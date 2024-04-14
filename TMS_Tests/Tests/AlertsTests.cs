using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TMS_Tests.Utils;

namespace TMS_Tests.Tests
{
    public class AlertsTests : BaseTest
    {
        IJavaScriptExecutor javaScriptExecutor;
        [SetUp]
        public void OpenSite()
        {
            Driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            javaScriptExecutor = (IJavaScriptExecutor)Driver;
        }

        [Test]
        public void AcceptAlert()
        {
            var clickMeAlertbutton = Driver.FindElement(By.XPath("//*[@id='confirmButton']"));
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", clickMeAlertbutton);
            clickMeAlertbutton.Click();

            var alert = Driver.SwitchTo().Alert();
            alert.Accept();
            var resultText = Driver.FindElement(By.XPath("//*[@id='confirmResult']")).Text.Trim();
            Assert.That(resultText, Is.EqualTo("You selected Ok"));
        }

        [Test]
        public void DeclineAlert()
        {
            var clickMeAlertbutton = Driver.FindElement(By.XPath("//*[@id='confirmButton']"));
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", clickMeAlertbutton);
            clickMeAlertbutton.Click();

            var alert = Driver.SwitchTo().Alert();
            alert.Dismiss();
            var resultText = Driver.FindElement(By.XPath("//*[@id='confirmResult']")).Text.Trim();
            Assert.That(resultText, Is.EqualTo("You selected Cancel"));
        }

        [Test]
        public void WaitForAlerdWithDelayAndCheckItsText()
        {
            var clickMeAlertbutton = Driver.FindElement(By.XPath("//*[@id='timerAlertButton']"));
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", clickMeAlertbutton);
            clickMeAlertbutton.Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut));
            wait.Until(ExpectedConditions.AlertIsPresent());

            var alert = Driver.SwitchTo().Alert();
            Assert.That(alert.Text.Trim, Is.EqualTo("This alert appeared after 5 seconds"));
        }

        [Test]
        public void EnterNameToAlert()
        {
            var clickMeAlertbutton = Driver.FindElement(By.XPath("//*[@id='promtButton']"));
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", clickMeAlertbutton);
            clickMeAlertbutton.Click();

            var alert = Driver.SwitchTo().Alert();
            alert.SendKeys("TestUser");
            alert.Accept();
            var resultText = Driver.FindElement(By.XPath("//*[@id='promptResult']")).Text.Trim();
            Assert.That(resultText, Is.EqualTo("You entered TestUser"));
        }
    }
}
