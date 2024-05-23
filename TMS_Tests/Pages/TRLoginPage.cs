using OpenQA.Selenium;
using TMS_Tests.Element;
using TMS_Tests.Utils;

namespace TMS_Tests.Pages
{
    public class TRLoginPage : BasePage
    {
        private string _endPoint = "";
        public UiElement EmailField() => new(Driver, By.Id("name"));
        public UiElement PasswordField() => new(Driver, By.Id("password"));
        public UiElement LogInButton() => new(Driver, By.Id("button_primary"));
        
        public TRLoginPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public override string GetEndpoint()
        {
            return _endPoint;
        }

        public void SuccessfulLogin()
        {
            ExecuteLoad();
            EmailField().SendKeys(Configurator.ReadConfiguration().TRLogin);
            PasswordField().SendKeys(Configurator.ReadConfiguration().TRPassword);
            LogInButton().Click();
        }

        protected override bool EvaluateLoadedStatus()
        {
            return LogInButton().Displayed;
        }
    }
}
