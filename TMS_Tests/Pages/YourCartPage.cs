using OpenQA.Selenium;

namespace TMS_Tests.Pages
{
    public class YourCartPage : BasePage
    {
        private string _endPoint = "cart.html";
        private static readonly By continueShoppingButtonBy = By.Id("continue-shopping");
        private static readonly By checkoutButtonBy = By.Id("checkout");
        private static readonly By cartItemBy = By.CssSelector(".cart_item");


        protected IWebDriver Driver { get; set; }

        public YourCartPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }
        public override string GetEndpoint()
        {
            return _endPoint;
        }

        public IWebElement ContinueShoppingButton() => Driver.FindElement(continueShoppingButtonBy);
        public IWebElement CheckoutButton() => Driver.FindElement(checkoutButtonBy);
        public IWebElement CartItem() => Driver.FindElement(cartItemBy);
    }
}
