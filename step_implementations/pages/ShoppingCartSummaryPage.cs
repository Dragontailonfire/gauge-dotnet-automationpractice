using FluentAssertions;
using Gauge.CSharp.Lib;
using OpenQA.Selenium;

namespace com.automationpractice.step_implementations.pages
{
    public class ShoppingCartSummaryPage
    {
        IWebDriver _webDriver;
        public ShoppingCartSummaryPage(IWebDriver webDriver) => _webDriver = webDriver;

        public void VerifyPageIsDisplayed()
        {
            By identifier = By.Id("cart_title");
            IWebElement element = _webDriver.FindElement(identifier);
            GaugeMessages.WriteMessage("SHOPPING-CART SUMMARY page is displayed.");
            GaugeScreenshots.Capture();
        }

        public void VerifyProductDetails(string name, string size, string quantity)
        {
            By identifierName = By.XPath("(//*[@class='product-name'])[2]");
            IWebElement elementName = _webDriver.FindElement(identifierName);
            By identifierSize = By.XPath("(//*[text()[contains(.,'Size')]])[2]");
            IWebElement elementSize = _webDriver.FindElement(identifierSize);
            By identifierQuantity = By.ClassName("cart_quantity_input");
            IWebElement elementQuantity = _webDriver.FindElement(identifierQuantity);

            //Take the entire text and take substring to get size and comapre
            string sizeText = elementSize.GetAttribute("innerText");
            int position = sizeText.LastIndexOf("Size : ");
            sizeText.Substring(position).Trim().Should().Be(size);

            //Comapre name
            string nameText = elementName.GetAttribute("innerText").Trim();
            nameText.Should().Be(name);

            //Comapre quantity
            string quantityText = elementName.GetProperty("value").Trim();
            quantityText.Should().Be(quantity);

            GaugeMessages.WriteMessage("Product details are matching.");
            GaugeScreenshots.Capture();
        }
	}
}