using OpenQA.Selenium;
using TMS_Tests.Element;

namespace TMS_Tests.Pages
{
    public class TRAddProjectPage : BasePage
    {
        private string _endPoint = "index.php?/admin/projects/add/1";
        public UiElement NameField() => new(Driver, By.Id("name"));
        public UiElement AddProjectSubmitButton() => new(Driver, By.Id("accept"));

        public TRAddProjectPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public override string GetEndpoint()
        {
            return _endPoint;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return NameField().Displayed;
        }
    }
}
