using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_Tests.Element;

namespace TMS_Tests.Pages
{
    public class TRLoginPage : BasePage
    {
        private string _endPoint = "";
        public IWebDriver Driver { get; set; }
        public UiElement EmailField = new(Driver, By.Id("name"));
        //public UiElement PasswordField = new(driver, By.Id("password']"));
        //public UiElement LogInButton = new(driver, By.Id("button_primary']"));
        public TRLoginPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }


        public override string GetEndpoint()
        {
            return _endPoint;
        }

        //public void SuccessfulLogin()
        //{
        //    EmailField.SendKeys("button_primary");
        //    PasswordField.SendKeys("tmsQAC0401?");
        //    LogInButton.Click();
        //}
    }
}
