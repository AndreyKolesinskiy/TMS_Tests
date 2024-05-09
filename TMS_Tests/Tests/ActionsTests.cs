using OpenQA.Selenium;

namespace TMS_Tests.Tests
{
    public class ActionsTests : BaseTest
    {
        [SetUp]
        public void OpenSite()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/context_menu");
        }

        [Test]
        public void HoverRightClickAndCheckAlertText()
        {
            var squareElement = Driver.FindElement(By.Id("hot-spot"));
            Actions
                .ContextClick(squareElement)
                .Build()
                .Perform();
            var alert = Driver.SwitchTo().Alert();
            Assert.That(alert.Text.Trim, Is.EqualTo("You selected a context menu"));
            alert.Accept();
        }
    }
}
