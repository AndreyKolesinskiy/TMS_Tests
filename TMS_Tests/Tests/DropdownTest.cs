using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V121.DOM;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace TMS_Tests.Tests
{
    [TestFixture]
    internal class DropdownTest : BaseTest
    {
        ReadOnlyCollection<IWebElement> dropdownOptions;
        SelectElement select;

        [SetUp]
        public void Setup()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
            dropdownOptions = Driver.FindElements(By.XPath("//select[@id='dropdown']/option"));
            select = new SelectElement(Driver.FindElement(By.Id("dropdown")));
        }

        [Test]
        public void CheckDropdownOptions()
        {
            Assert.AreEqual("Please select an option", dropdownOptions[0].Text);
            Assert.AreEqual("Option 1", dropdownOptions[1].Text);
            Assert.AreEqual("Option 2", dropdownOptions[2].Text);
        }

        [Test]
        public void SelectFirstOption()
        {
            
            select.SelectByIndex(1);
            Assert.IsTrue(select.SelectedOption.GetAttribute("value").Equals("1"));
        }

        [Test]
        public void SelectSecondOption()
        {
            select.SelectByIndex(2);
            Assert.IsTrue(select.SelectedOption.GetAttribute("value").Equals("2"));
        }
    }
}
