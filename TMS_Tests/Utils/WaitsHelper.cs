using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Tests.Utils
{
    public class WaitsHelper
    {
        private IWebDriver driver;
        private WebDriverWait _wait;
        private TimeSpan _timeout;

        public WaitsHelper(IWebDriver driver, TimeSpan timeout)
        {
            this.driver = driver;
            this._timeout = timeout;
            _wait = new WebDriverWait(driver, _timeout);
        }

        public IWebElement WaitForVisibility(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public bool WaitForElementInvisible(By locator)
        {
            return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public bool WaitForElementInvisible(IWebElement element)
        {
            try
            {
                _wait.Until(d => !element.Displayed);
                return true;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Element visible after {_timeout} seconds");
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
        }


    }
}
