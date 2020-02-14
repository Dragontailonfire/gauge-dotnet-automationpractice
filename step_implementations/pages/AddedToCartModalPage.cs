using FluentAssertions;
using Gauge.CSharp.Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace com.automationpractice.step_implementations.pages
{
    public class AddedToCartModalPage
    {
        IWebDriver _webDriver;
        public AddedToCartModalPage(IWebDriver webDriver) => _webDriver = webDriver;

        public void VerifyPageIsDisplayed()
        {
            
            By identifier = By.XPath("//*[text()[contains(.,'Product successfully added to your shopping cart')]]");
            IWebElement element = _webDriver.FindElement(identifier);
            GaugeMessages.WriteMessage("Added to cart page is displayed.");
            GaugeScreenshots.Capture();
        }

        public void ClickProceedToCheckout()
        {
            By identifier = By.XPath("//*[text()[contains(.,'Proceed to checkout')]]");
            IWebElement element = _webDriver.FindElement(identifier);
            element.Click();
            GaugeMessages.WriteMessage("Proceed to checkout is clicked.");
            GaugeScreenshots.Capture();
        }
	}
}