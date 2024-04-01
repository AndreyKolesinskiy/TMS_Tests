using OpenQA.Selenium;

namespace TMS_Tests.Tests
{
    internal class CheckboxesTest : BaseTest
    {
        [Test]
        public void CheckUncheckCheckboxes()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");
            var checkboxes = Driver.FindElements(By.CssSelector("[type = checkbox]"));
            Assert.IsFalse(checkboxes[0].Selected);

            checkboxes[0].Click();
            Assert.IsTrue(checkboxes[0].Selected);
            Assert.IsTrue(checkboxes[1].Selected);

            checkboxes[1].Click();
            Assert.IsFalse(checkboxes[1].Selected);
        }
    }
}
