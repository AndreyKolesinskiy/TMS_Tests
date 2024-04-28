namespace TMS_Tests.Tests
{
    [TestFixture]
    public class TestRailTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            TRLoginPage.OpenTRPageByUrl();
            TRLoginPage.SuccessfulLogin();
        }

        [Test]
        public void CreateTestProject()
        {
            TRDashboardPage.AddProjectButton.Click();
            string projectName = "AKaliasinskiTestProject " + DateTime.Now;
            TRAddProjectPage.NameField.SendKeys(projectName);
            TRAddProjectPage.AddProjectSubmitButton.Click();
            Assert.That(TRProjectsPage.GetNewCreatedProjectElement(projectName).Displayed);
        }
    }
}


