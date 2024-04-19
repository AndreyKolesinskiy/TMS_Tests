using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using TMS_Tests.Utils;

namespace TMS_Tests.Tests
{
    [TestFixture]
    internal class YourCartPageTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            LoginPage.OpenPageByUrl();
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
                Configurator.ReadConfiguration().PasswordSauceDemo);
            YourCartPage.OpenPageByUrl();
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Test description")]
        [AllureName("Check continue shopping button")]
        [AllureStep]
        [AllureParentSuite("Cart suite")]
        [AllureSuite("Shopping cart suite")]
        [AllureSubSuite("Shopping cart buttons suite")]
        [AllureOwner("AKaliasisnki")]
        [AllureIssue("BUG-01")]
        [AllureTms("TMS-011")]
        [AllureLink("WebSite", "https://www.saucedemo.com")]
        public void ContinueShoppingButtonIsDisplayed()
        {
            Assert.That(YourCartPage.ContinueShoppingButton().Displayed, Is.True);
        }

        [Test]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureDescription("Test description")]
        [AllureName("Check that CHckout button is displayed")]
        [AllureStep]
        [AllureParentSuite("Cart suite")]
        [AllureSuite("Shopping cart suite")]
        [AllureSubSuite("Checkout button suite")]
        [AllureOwner("AKaliasisnki")]
        public void CheckoutButtonIsDisplayed()
        {
            Assert.That(YourCartPage.CheckoutButton().Displayed, Is.True);
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureDescription("Test description")]
        [AllureName("After clicking Continue Shopping button user is navigated to Products page")]
        [AllureStep]
        [AllureEpic("Cart page")]
        [AllureFeature("Adding item to cart")]
        [AllureStory("Navigation to Products page")]
        [AllureOwner("AKaliasisnki")]
        public void AfterCLickingContinueShoppingUserIsNavigatedToProductsPage()
        {
            YourCartPage.ContinueShoppingButton().Click();
            Assert.That(Driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }


        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureDescription("Test description")]
        [AllureName("Check that added item is displayed in cart")]
        [AllureStep]
        [AllureEpic("Cart page")]
        [AllureFeature("Adding item to cart")]
        [AllureStory("Item in cart")]
        [AllureOwner("AKaliasisnki")]
        public void ItemIsDisplayedInCart()
        {
            ProductsPage.OpenPageByUrl();
            ProductsPage.AddToCartButtons()[0].Click();
            YourCartPage.OpenPageByUrl();
            Assert.That(YourCartPage.CartItem().Displayed, Is.True);
        }

        [Test]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureDescription("Test description")]
        [AllureName("Check that test fails and screenshot is added")]
        [AllureStep]
        [AllureEpic("Cart page")]
        [AllureFeature("Adding item to cart")]
        [AllureStory("Item in cart")]
        [AllureOwner("AKaliasisnki")]
        [AllureIssue("BUG-01")]
        [AllureTms("TMS-011")]
        [AllureLink("WebSite", "https://www.saucedemo.com")]
        public void FailingTest()
        {
            ProductsPage.OpenPageByUrl();
            ProductsPage.AddToCartButtons()[0].Click();
            YourCartPage.OpenPageByUrl();
            Assert.That(false);
        }

    }
}
