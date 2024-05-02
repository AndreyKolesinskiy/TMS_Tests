namespace TMS_Tests.Tests
{
    [TestFixture]
    public class TestRailTests : BaseTest
    {
        public string projectName;

        [SetUp]
        public void SetUp()
        {
            TRLoginPage.SuccessfulLogin();
        }

        [Test]
        public void CreateTestProject()
        {
            TRDashboardPage.AddProjectButton().Click();
            projectName = "AKaliasinskiTestProject " + DateTime.Now;
            TRAddProjectPage.NameField().SendKeys(projectName);
            TRAddProjectPage.AddProjectSubmitButton().Click();
            Assert.That(TRProjectsPage.GetNewCreatedProjectElement(projectName).Displayed);
        }

        [Test]
        public void DeleteTestProject()
        {
            CreateTestProject();
            TRProjectsPage.GetDeleteButtonForProject(projectName).Click();
            TRProjectsPage.DeleteCheckbox().Click();
            TRProjectsPage.DeleteDialogOKButtton().Click();
            Assert.That(TRProjectsPage.ProjectIsDeleted(projectName), Is.True);
        }
    }
}


