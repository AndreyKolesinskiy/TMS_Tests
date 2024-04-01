using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TMS_Tests.Tests
{
    internal class DropdownTest : BaseTest
    {
        [Test]
        public void CheckDropdownOptions()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            var dropdownOptions = Driver.FindElements(By.XPath("//select[@id='dropdown']/option"));
            Assert.AreEqual("Please select an option", dropdownOptions[0].Text);
            Assert.AreEqual("Option 1", dropdownOptions[1].Text);
            Assert.AreEqual("Option 2", dropdownOptions[2].Text);
            var dropdown = Driver.FindElement(By.Id("dropdown"));
            var select = new SelectElement(dropdown);
            select.SelectByIndex(1);
            Assert.IsTrue(select.SelectedOption.GetAttribute("value").Equals("1"));
            select.SelectByIndex(2);
            Assert.IsTrue(select.SelectedOption.GetAttribute("value").Equals("2"));
        }
    }
}
