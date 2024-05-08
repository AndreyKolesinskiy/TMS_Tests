using TMS_Tests.Models;
using TMS_Tests.Pages;

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

            var project = new ProjectModel()
            {
                Name = "AKaliasinskiTestProject ",
                Announcement = "Test announcement",
                IsShowAnnouncement = true,
                ProjectType = "Use a single repository for all cases (recommended)",
                IsEnableTestCaseApprovals = true
            };

            projectName = project.Name + DateTime.Now;
            TRAddProjectPage.NameField().SendKeys(projectName);
            TRAddProjectPage.AnnouncmentField().SendKeys(project.Announcement);
            TRAddProjectPage.SelectShowAnnouncementIfTrue(project.IsShowAnnouncement);
            TRAddProjectPage.SelectPojectType(project.ProjectType);
            TRAddProjectPage.SelectTestCaseApprovalsIfTrue(project.IsEnableTestCaseApprovals);
            TRAddProjectPage.AddProjectSubmitButton().Click();
            Assert.That(TRProjectsPage.GetNewCreatedProjectElement(projectName).Displayed);
        }

        [Test]
        public void DeleteTestProject()
        {
            CreateTestProject();
            TRProjectsPage.GetDeleteButtonForProject(projectName).Click();
            TRProjectsPage.DeleteCheckbox().EnableCheckbox();
            TRProjectsPage.DeleteDialogOKButtton().Click();
            Assert.That(TRProjectsPage.ProjectIsDeleted(projectName), Is.True);
        }
    }
}


