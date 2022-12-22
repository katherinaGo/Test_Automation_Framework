using System.Configuration;

namespace Epam.TestAutomation.Core.Helper
{
    public static class TestSettings
    {
        public static readonly string ApplicationUrl = GetConfigurationValue("ApplicationUrl");

        public static readonly string LogsPath =
            Path.Combine(Directory.GetCurrentDirectory(), GetConfigurationValue("LogsPath"));

        public static string TestResourcesFolder => Path.Combine(Directory.GetCurrentDirectory(),
            GetConfigurationValue("TestResourcesFolder"));

        public static string UserName => GetConfigurationValue("UserName");

        public static string UserPassword => GetConfigurationValue("UserPassword");

        public static string GetConfigurationValue(string parameter) =>
            ConfigurationManager.AppSettings.Get(parameter);
    }
}