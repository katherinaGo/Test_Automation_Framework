using System.Collections.ObjectModel;
using Epam.TestAutomation.Core.Browser;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements;

public class BaseElement
{
    protected IWebElement FindElement(By by) => DriverFactory.Driver.FindElement(by);

    protected ReadOnlyCollection<IWebElement> FindElements(By by) => DriverFactory.Driver.FindElements(by);

    protected void ClickButton(By selector) => FindElement(selector).Click();

    protected void InputDataToField(By selector, string textToType) => FindElement(selector).SendKeys(textToType);

    protected bool IsElementDisplayedOnPage(By selector) => FindElement(selector).Displayed;
}