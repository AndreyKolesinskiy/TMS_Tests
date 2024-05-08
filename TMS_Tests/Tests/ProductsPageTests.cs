using TMS_Tests.Utils;

namespace TMS_Tests.Tests
{
    [TestFixture]
    internal class ProductsPageTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            LoginPage.OpenPageByUrl();
            LoginPage.SuccessfulLogin(Configurator.ReadConfiguration().UserNameSauceDemo,
                Configurator.ReadConfiguration().PasswordSauceDemo);
            ProductsPage.OpenPageByUrl();
        }

        [Test]
        public void AddToCartButtonIsDisplayed()
        {
            Assert.That(ProductsPage.AddToCartButtons().Count() > 0, Is.True);
        }

        [Test]
        public void RemoveButtonIsDisplayedAfterClickOnAddToCartButton()
        {
            ProductsPage.AddToCartButtons()[0].Click();
            Assert.That(ProductsPage.RemoveButton().Displayed, Is.True);
        }

        [Test]
        public void RemoveButtonDisappearsAfterClickingOnIt()
        {
            ProductsPage.AddToCartButtons()[0].Click();
            ProductsPage.RemoveButton().Click();
            Assert.That(ProductsPage.RemoveButtons().Count == 0, Is.True);
        }
    }
}
