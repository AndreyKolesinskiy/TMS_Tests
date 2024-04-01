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
            Assert.AreNotEqual("selenium", input.Text);
            input.Clear();
            input.SendKeys("5");
            Assert.AreEqual("5", input.Text);
            input.SendKeys(Keys.ArrowUp);
            input.SendKeys("6");
            input.SendKeys(Keys.ArrowDown);
            input.SendKeys("5");
        }
    }
}
