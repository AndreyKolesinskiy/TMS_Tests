using OpenQA.Selenium;
using TMS_Tests.Utils;

namespace TMS_Tests.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver {  get; set; }

        public BasePage (IWebDriver driver)
        {
            Driver = driver;
        }
        public abstract string GetEndpoint();

        public void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().BaseUrl + GetEndpoint());
        }
    }
}
