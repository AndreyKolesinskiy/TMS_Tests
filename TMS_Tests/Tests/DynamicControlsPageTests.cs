using OpenQA.Selenium;
using TMS_Tests.Utils;

namespace TMS_Tests.Tests
{
    [TestFixture]
    public class DynamicControlsPageTests : BaseTest
    {
        [SetUp]
        public void OpenSite()
        {
            Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
        }

        [Test]
        public void CheckThatCheckboxDisappeared()
        {
            var checkbox = Driver.FindElement(By.XPath("//*[@id='checkbox']"));
            var removeButton = Driver.FindElement(By.XPath("//button[text()='Remove']"));

            Assert.That(checkbox.Displayed, Is.True);

            removeButton.Click();
            var loadingElement = Driver.FindElement(By.XPath("//*[@id='loading']"));

            Assert.That(loadingElement.Displayed, Is.True);

            var messageText = Driver.FindElement(By.XPath("//*[@id='message']"));
            WaitsHelper.WaitForElementInvisible(loadingElement);
            WaitsHelper.WaitForElementInvisible(checkbox);

            Assert.That(messageText.Displayed, Is.True);
        }
    }
}
