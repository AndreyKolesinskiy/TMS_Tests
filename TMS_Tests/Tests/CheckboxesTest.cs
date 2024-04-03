using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace TMS_Tests.Tests
{
    [TestFixture]
    internal class CheckboxesTest : BaseTest
    {
        ReadOnlyCollection<IWebElement> checkboxes;

        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");
            checkboxes = Driver.FindElements(By.CssSelector("[type = checkbox]"));
        }

        [Test]
        public void FirstCheckboxIsNotSelected()
        {
            Assert.IsFalse(checkboxes[0].Selected);
        }

        [Test]
        public void AllCheeckboxesAreSelected()
        {
            checkboxes[0].Click();
            Assert.IsTrue(checkboxes[0].Selected);
            Assert.IsTrue(checkboxes[1].Selected);
        }

        [Test]
        public void SecondCheckboxIsNotSelected()
        {
            checkboxes[1].Click();
            Assert.IsFalse(checkboxes[1].Selected);
        }
    }
}
