using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace TMS_Tests
{
    [TestFixture]
    internal class Locators : BaseTest
    {
        //Login page locators
        private string loginButtonIdLocator = "login-button";
        private string passwordFieldNameLocator = "password";
        private string sectionWithPasswordClassNameLocator = "login_password";
        private string userNameInputTagNameNameLocator = "input";
        private string usernameByXpath = "//input[@placeholder='Username']";
        private string usernamesSectionByXpath = "//*[text()='Accepted usernames are:']";
        private string passwordSectionByXpath = "//*[contains(text(),'Password')]";
        private string loginContainerByXpath = "//*[contains(@class,'login_cont')]";
        private string loginButtonContainerByXpath = "//*[@placeholder='Password']//ancestor::*[@id='login_button_container']";
        private string loginBoxByXpath = "//*[@id='login_button_container']//descendant::div[@class='login-box']";
        private string errorMessageContainerByXpath = "//*[@id='login_button_container']//following::*[@class='error-message-container']";
        private string parentOfPasswordFieldByXpath = "//*[@id='password']/parent::div";
        private string loginLogoByXpath = "//*[@id='password']//preceding::*[@class='login_logo']";
        private string usernameFieldAsChildByXpath = "//*[@class='login_wrapper']//child::*[@placeholder='Username']";
        private string loginButtonClassnameByCss = ".submit-button";
        private string loginButtonTwoClassnamesByCss = ".submit-button.btn_action";
        private string usernameTagnameByCss = "input";
        private string loginButtonTgnameAndClassByCss = "input.submit-button";
        private string logoAttributeClassByCss = "[class=login_logo]";
        private string usernameErrorInputClassByCss = "[class~=input_error]";
        private string usernameErrorXcircleByCss = "[data-icon|=times]";
        private string usernameFieldInputFromErrorByCss = "[class^=error]";
        private string loginButtonBySiffixedValueByCss = "[[class$=btn_action]]";

        // Products page locators
        private string twitterByLinkTextLocator = "https://twitter.com/saucelabs";
        private string facebookByPartialLinkTextLocator = "www.facebook";
        private string addToCartButton = "[class*=btn_inventory ]";

        // Product page locators
        private string addToCartButtonTwoClassesByCss = ".inventory_details_desc_container .btn_primary";
        private string addToCartButtonIdsByCss = "#add-to-cart";

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        // Tests for some locators
        [Test]
        public void loginButtonIsDisplayed()
        {

            Assert.That(Driver.FindElement(By.Id(loginButtonIdLocator)).Displayed, Is.True);
        }

        [Test]
        public void passworFieldIsDisplayed()
        {
            Assert.That(Driver.FindElement(By.Name(passwordFieldNameLocator)).Displayed, Is.True);
        }

        [Test]
        public void sectionWithPasswordIsDisplayed()
        {
            Assert.That(Driver.FindElement(By.ClassName(sectionWithPasswordClassNameLocator)).Displayed, Is.True);
        }

        [Test]
        public void usernameInputIsDisplayed()
        {
            Assert.That(Driver.FindElements(By.TagName(userNameInputTagNameNameLocator))[0].Displayed, Is.True);
        }
    }
}
