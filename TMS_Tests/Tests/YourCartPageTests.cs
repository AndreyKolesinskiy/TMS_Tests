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
        public void ContinueShoppingButtonIsDisplayed()
        {
            Assert.That(YourCartPage.ContinueShoppingButton().Displayed, Is.True);
        }

        [Test]
        public void CheckoutButtonIsDisplayed()
        {
            Assert.That(YourCartPage.CheckoutButton().Displayed, Is.True);
        }

        [Test]
        public void AfterCLickingContinueShoppingUserIsNavigatedToProductsPage()
        {
            YourCartPage.ContinueShoppingButton().Click();
            Assert.That(Driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }

        [Test]
        public void ItemIsDisplayedInCart()
        {
            ProductsPage.OpenPageByUrl();
            ProductsPage.AddToCartButtons()[0].Click();
            YourCartPage.OpenPageByUrl();
            Assert.That(YourCartPage.CartItem().Displayed, Is.True);
        }
    }
}
