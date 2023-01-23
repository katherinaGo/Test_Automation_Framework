using System.ComponentModel;

namespace Epam.TestAutomation.Core.Enums;

public enum BrowserType
{
    [Description("DefaultBrowser")] Chrome,

    [Description("OtherBrowser")] Safari
}