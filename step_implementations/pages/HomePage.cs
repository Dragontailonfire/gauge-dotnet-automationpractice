using Gauge.CSharp.Lib;
using OpenQA.Selenium;

namespace com.automationpractice.step_implementations.pages
{
    public class HomePage
    {
        IWebDriver _webDriver;
        public HomePage(IWebDriver webDriver) => _webDriver = webDriver;

        public void ClickMenuItem(string item)
        {
            By identifier = By.LinkText(item);
            IWebElement element = _webDriver.FindElement(identifier);
            element.Click();
            GaugeMessages.WriteMessage("'" + item + "' menu item is clicked.");
            GaugeScreenshots.Capture();
        }
    }
}