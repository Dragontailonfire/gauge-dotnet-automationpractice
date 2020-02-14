using FluentAssertions;
using Gauge.CSharp.Lib;
using OpenQA.Selenium;

namespace com.automationpractice.step_implementations.pages
{
    public class SearchCategoryResultPage
    {
        IWebDriver _webDriver;
        public SearchCategoryResultPage(IWebDriver webDriver) => _webDriver = webDriver;

        public void VerifyPageIsDisplayed(string category)
        {
            By identifier = By.ClassName("cat-name");
            IWebElement element = _webDriver.FindElement(identifier);
            string categoryTitle = element.GetAttribute("innerText").Trim();
            categoryTitle.Should().Be(category);
            GaugeMessages.WriteMessage("'" + category + "' Category is displayed.");
            GaugeScreenshots.Capture();
        }

        public void OpenProduct(string product)
        {
            By identifier = By.XPath("(//a[@title='" + product + "'])[2]");
            IWebElement element = _webDriver.FindElement(identifier);
            element.Click();
        }
    }
}