using OpenQA.Selenium;

namespace TMS_Tests.Tests
{
    [TestFixture]
    internal class InputsTest : BaseTest
    {
        IWebElement input;
        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");
            input = Driver.FindElement(By.TagName("input"));
        }

        [Test]
        public void EnterTextValueToInput()
        {
            input.SendKeys("selenium");
            Assert.AreNotEqual("selenium", input.GetAttribute("value"));
        }

        [Test]
        public void ExitNumericValueToInput()
        {
            input.SendKeys("5");
            Assert.AreEqual("5", input.GetAttribute("value"));
        }

        [Test]
        public void ValueInreasedByUpArrow()
        {
            input.SendKeys("5");
            input.SendKeys(Keys.ArrowUp);
            Assert.AreEqual("6", input.GetAttribute("value"));
        }

        [Test]
        public void ValueDereasedByDownArrow()
        {
            input.SendKeys("5");
            input.SendKeys(Keys.ArrowDown);
            Assert.AreEqual("4", input.GetAttribute("value"));
        }
    }
}
