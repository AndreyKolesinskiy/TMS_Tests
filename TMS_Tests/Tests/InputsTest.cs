using OpenQA.Selenium;

namespace TMS_Tests.Tests
{
    internal class InputsTest : BaseTest
    {
        [Test]
        public void SetValueToInput()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");
            var input = Driver.FindElement(By.TagName("input"));
            input.SendKeys("selenium");
            Assert.AreNotEqual("selenium", input.GetAttribute("value"));
            input.Clear();
            input.SendKeys("5");
            Assert.AreEqual("5", input.GetAttribute("value"));
            input.SendKeys(Keys.ArrowUp);
            Assert.AreEqual("6", input.GetAttribute("value"));
            input.SendKeys(Keys.ArrowDown);
            Assert.AreEqual("5", input.GetAttribute("value"));
        }
    }
}
