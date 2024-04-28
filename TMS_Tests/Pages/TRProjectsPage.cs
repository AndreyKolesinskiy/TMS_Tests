using OpenQA.Selenium;
using TMS_Tests.Element;

namespace TMS_Tests.Pages
{
    public class TRProjectsPage : BasePage
    {
        private string _endPoint = "index.php?/admin/projects/overview";
        public UiElement GetNewCreatedProjectElement(string projectName)
        {
                return new(Driver, By.XPath($"//*[text()='{projectName}']"));
        }

        public TRProjectsPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public override string GetEndpoint()
        {
            return _endPoint;
        }
    }
}
