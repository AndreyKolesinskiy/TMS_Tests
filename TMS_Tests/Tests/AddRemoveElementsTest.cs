using OpenQA.Selenium;

namespace TMS_Tests.Tests
{
    internal class AddRemoveElementsTest : BaseTest
    {
        [Test]
        public void AddRemoveElements()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            Driver.FindElement(By.XPath("//button[text()='Add Element']")).Click();
            Driver.FindElement(By.XPath("//button[text()='Add Element']")).Click();
            Driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            var deleteButtons = Driver.FindElements(By.XPath("//button[text()='Add Element']"));

            Assert.IsTrue(deleteButtons.Count() == 1, "Incorrecnt number of buttons");
        }
    }
}
