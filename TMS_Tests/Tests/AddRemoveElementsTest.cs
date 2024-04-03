using OpenQA.Selenium;

namespace TMS_Tests.Tests
{
    [TestFixture]
    internal class AddRemoveElementsTest : BaseTest
    {
        [Test]
        public void AddRemoveElements()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            var addElementButton = Driver.FindElement(By.XPath("//button[text()='Add Element']"));
            addElementButton.Click();
            addElementButton.Click();
            Driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            var deleteButtons = Driver.FindElements(By.XPath("//button[text()='Delete']"));

            Assert.IsTrue(deleteButtons.Count() == 1, "Incorrecnt number of buttons");
        }
    }
}
