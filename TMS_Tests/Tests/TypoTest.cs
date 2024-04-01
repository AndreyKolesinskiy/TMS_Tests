using OpenQA.Selenium;

namespace TMS_Tests.Tests
{
    internal class TypoTest : BaseTest
    {
        [Test]
        public void CompareText()
        {
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/typos");
            var displayedText = Driver.FindElements(By.TagName("p"));
            Assert.AreEqual("Sometimes you'll see a typo, other times you won't.", displayedText[1].Text);
        }
    }
}
