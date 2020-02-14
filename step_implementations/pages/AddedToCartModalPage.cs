using System.Threading;
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
            //The dynamic waits are not working in this case. Adding sleep as temporary workaround.
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(_webDriver, new System.TimeSpan(0, 0, 30));
            By identifier = By.XPath("//*[text()[contains(.,'Proceed to checkout')]]");
            IWebElement element = wait.Until(e => e.FindElement(identifier));
            element.Click();
            GaugeMessages.WriteMessage("Proceed to checkout is clicked.");
            GaugeScreenshots.Capture();
        }
	}
}