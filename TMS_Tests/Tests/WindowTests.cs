using OpenQA.Selenium;

namespace TMS_Tests.Tests
{
    public class WindowTests : BaseTest
    {
        [SetUp]
        public void OpenSite()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
        }

        [Test]
        [Category("Other_tests")]
        public void OpenNewWindow()
        {
            var initialWindowHandle = Driver.CurrentWindowHandle;
            var clickHereLink = Driver.FindElement(By.LinkText("Click Here"));
            clickHereLink.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            Assert.Multiple(() =>
            {
                Assert.That(Driver.WindowHandles.Count(), Is.EqualTo(2));
                Assert.That(Driver.FindElement(By.TagName("h3")).Text, Is.EqualTo("New Window"));
            });

            Driver.SwitchTo().Window(initialWindowHandle);
            Assert.That(clickHereLink.Displayed);
        }

        [Test]
        [Category("Other_tests")]
        public void OpenNewWindowAndCLoseIt()
        {
            var initialWindowHandle = Driver.CurrentWindowHandle;
            var clickHereLink = Driver.FindElement(By.LinkText("Click Here"));
            clickHereLink.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            Assert.That(Driver.WindowHandles.Count(), Is.EqualTo(2));
            Driver.Close();

            Driver.SwitchTo().Window(initialWindowHandle);
            Assert.That(Driver.WindowHandles.Count(), Is.EqualTo(1));
        }
    }
}
