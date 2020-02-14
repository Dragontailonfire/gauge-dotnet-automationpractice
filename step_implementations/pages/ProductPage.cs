using Gauge.CSharp.Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace com.automationpractice.step_implementations.pages
{
    public class ProductPage
    {
        IWebDriver _webDriver;
        public ProductPage(IWebDriver webDriver) => _webDriver = webDriver;

        public void VerifyPageIsDisplayed(string product)
        {
            By identifier = By.XPath("//h1[@itemprop='name']");
            IWebElement element = _webDriver.FindElement(identifier);
            GaugeMessages.WriteMessage("'" + product + "' details page is displayed.");
            GaugeScreenshots.Capture();
        }

        public void GiveProductQuantity(string quantity)
        {
            By identifier = By.Id("quantity_wanted");
            IWebElement element = _webDriver.FindElement(identifier);
            element.Clear();
            element.SendKeys(quantity);
            GaugeMessages.WriteMessage("'" + quantity + "' quantity is given.");
            GaugeScreenshots.Capture();
        }

        public void SelectProductSize(string size)
        {
            By identifier = By.Id("group_1");
            IWebElement element = _webDriver.FindElement(identifier);
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText(size);
            GaugeMessages.WriteMessage("'" + size + "' quantity is selected.");
            GaugeScreenshots.Capture();
        }

        public void ClickAddToCart()
        {
            By identifier = By.XPath("//*[text()[contains(.,'Add to cart')]]");
            IWebElement element = _webDriver.FindElement(identifier);
            element.Click();
            GaugeMessages.WriteMessage("Add to cart is clicked.");
            GaugeScreenshots.Capture();
        }
    }
}