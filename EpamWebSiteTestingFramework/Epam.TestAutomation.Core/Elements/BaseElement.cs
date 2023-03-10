using System.Collections.ObjectModel;
using Epam.TestAutomation.Core.DriverCreator;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Epam.TestAutomation.Core.Elements;

public abstract class BaseElement
{
    public IWebElement Element { get; }

    protected BaseElement(By locator)
    {
        Element = Browser.Driver.FindElement(locator);
    }

    protected BaseElement(IWebElement element)
    {
        Element = element;
    }

    public string GetText() => Element.Text.Trim();
    public string GetTextFromAttribute(string value) => Element.GetAttribute(value);
    public void Click() => Element.Click();
    public void SendKeys(string text) => Element.SendKeys(text);
    public void ClearField() => Element.Clear();
    public bool IsElementDisplayedOnPage() => Element.Displayed;
    public bool IsElementEnabled() => Element.Enabled;
    public IWebElement FindTheElement(By locator) => Element.FindElement(locator);
    public ReadOnlyCollection<IWebElement> FindTheElements(By locator) => Element.FindElements(locator);

    public bool IsElementOnView()
    {
        var script = "var elem = arguments[0],                 " +
                     "  box = elem.getBoundingClientRect(),    " +
                     "  cx = box.left + box.width / 2,         " +
                     "  cy = box.top + box.height / 2,         " +
                     "  e = document.elementFromPoint(cx, cy); " +
                     "for (; e; e = e.parentElement) {         " +
                     "  if (e === elem)                        " +
                     "    return true;                         " +
                     "}                                        " +
                     "return false;                            ";
        return (bool)Browser.Driver.ExecuteScript(script, Element);
    }

    public void ClickUsingJS()
    {
        Browser.Driver.ExecuteScript("arguments[0].click()", Element);
    }

    public void DragAndDrop(BaseElement targetElement)
    {
        CreateAction().DragAndDrop(Element, targetElement.Element).Build().Perform();
    }

    public void DoubleClick()
    {
        CreateAction().DoubleClick(Element).Build().Perform();
    }

    private Actions CreateAction()
    {
        return Browser.Driver.GetActions();
    }

    public void HoverOnElement()
    {
        Browser.Driver.GetActions().MoveToElement(Element).Perform();
    }
}