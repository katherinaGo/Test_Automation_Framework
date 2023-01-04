using System.Collections.ObjectModel;
using Epam.TestAutomation.Core.DriverCreator;
using OpenQA.Selenium;

namespace Epam.TestAutomation.Core.Elements;

public class ElementsList<T>
{
    private readonly List<IWebElement> _elements;
    private readonly By _locator;
    private readonly IWebElement _element;

    public ElementsList(By locator)
    {
        _locator = locator;
        _elements = FindElements(locator).ToList();
    }

    public List<IWebElement> GetElements()
    {
        return _elements.ToList();
    }

    public ReadOnlyCollection<IWebElement> FindElements(By locator)
    {
        if (_element != null)
        {
            return _element.FindElements(locator);
        }

        return Browser.Driver.FindElements(locator);
    }
}