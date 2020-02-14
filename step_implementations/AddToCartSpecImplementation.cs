using System;
using com.automationpractice.step_implementations.pages;
using com.automationpractice.components;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;

namespace com.automationpractice.step_implementations
{
    public class AddToCartSpecImplementation
    {
        IWebDriver _webDriver;
        HomePage _homePage;
        SearchCategoryResultPage _searchCategoryResultPage;
        ProductPage _productPage;
        AddedToCartModalPage _addedToCartModalPage;
        ShoppingCartSummaryPage _shoppingCartSummaryPage;

        public AddToCartSpecImplementation()
        {
            _webDriver = WebDriverManager.Driver;
            _homePage = new HomePage(_webDriver);
            _searchCategoryResultPage = new SearchCategoryResultPage(_webDriver);
            _productPage = new ProductPage(_webDriver);
            _addedToCartModalPage = new AddedToCartModalPage(_webDriver);
            _shoppingCartSummaryPage = new ShoppingCartSummaryPage(_webDriver);
        }

        [Step("Open application")]
        public void OpenApplication()
        {
            string url = Environment.GetEnvironmentVariable("test_url");
            _webDriver.Navigate().GoToUrl(url);
            _webDriver.Manage().Window.Maximize();
        }

        [Step("Click <menuItem> menu item")]
        public void ClickMenuItem(string menuItem)
        {
            _homePage.ClickMenuItem(menuItem);
        }

        [Step("Verify <categoryName> search category is displayed")]
        public void VerifySearchCategoryIsDisplayed(string categoryName)
        {
            _searchCategoryResultPage.VerifyPageIsDisplayed(categoryName);
        }

        [Step("Open product with title <productName>")]
        public void OpenProductWithTitle(string productName)
        {
            _searchCategoryResultPage.OpenProduct(productName);
        }

        [Step("Verify <productName> product page is displayed")]
        public void VerifyProductPageIsDisplayed(string productName)
        {
            _productPage.VerifyPageIsDisplayed(productName);
        }

        [Step("Specify product quantity as <productQuantity>")]
        public void SpecifyProductQuantityAs(string productQuantity)
        {
            _productPage.GiveProductQuantity(productQuantity);
        }

        [Step("Specify product size as <productSize>")]
        public void SpecifyProductSizeAs(string productSize)
        {
            _productPage.SelectProductSize(productSize);
        }

        [Step("Click add to cart button in product page")]
        public void ClickAddToCartButtonInProductPage()
        {
            _productPage.ClickAddToCart();
        }
    
		[Step("Verify Added to cart message")]
		public void VerifyAddedToCartMessage()
		{
			_addedToCartModalPage.VerifyPageIsDisplayed();
		}
	
		[Step("Click Proceed to Checkout button in 'Added to cart' modal window")]
		public void ClickProceedToCheckoutButtonInAddedToCartModalWindow()
		{
			_addedToCartModalPage.ClickProceedToCheckout();
		}
	
		[Step("Verify product details Name = <name>, Size = <size>, Quantity = <quantity>")]
		public void VerifyProductDetailsNameSizeQuantity(string name, string size, string quantity)
		{
			_shoppingCartSummaryPage.VerifyProductDetails(name, size, quantity);
		}
	
		[Step("Verify Shopping Cart Sumamry page is displayed")]
		public void VerifyShoppingCartSumamryPageIsDisplayed()
		{
			_shoppingCartSummaryPage.VerifyPageIsDisplayed();
		}
	}
}