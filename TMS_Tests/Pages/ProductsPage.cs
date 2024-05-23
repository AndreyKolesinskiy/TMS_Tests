using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace TMS_Tests.Pages
{
    public class ProductsPage : BasePage
    {
        private static readonly By ProductsTitleBy = By.XPath("//*[.='Products']");
        private string _endPoint = "inventory.html";
        private static readonly By addToCartButtons = By.XPath("//*[text()= 'Add to cart']");
        private static readonly By RemoveButtonBy = By.XPath("//*[text()= 'Remove']");

        protected IWebDriver Driver { get; set; }

        public ProductsPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public override string GetEndpoint()
        {
            return _endPoint;
        }

        public IWebElement ProductsTitle() => Driver.FindElement(ProductsTitleBy);
        public ReadOnlyCollection<IWebElement> AddToCartButtons() => Driver.FindElements(addToCartButtons);
        public IWebElement RemoveButton() => Driver.FindElement(RemoveButtonBy);
        public ReadOnlyCollection<IWebElement> RemoveButtons() => Driver.FindElements(RemoveButtonBy);

        protected override bool EvaluateLoadedStatus()
        {
            return ProductsTitle().Displayed;
        }
    }
}
