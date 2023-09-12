using System;
using System.IO;
using Warehouse.Settings;

namespace Warehouse
{
    public static class ApplicationContext
    {
        public static AppSettings Settings { get; private set; }
        public static void Initialize()
        {
            Settings = InitializeSettings();
            if (Settings == null)
            { }
        }

        private static AppSettings InitializeSettings()
        {
            string settingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settingPath = Path.Combine(settingPath, "Warehouse");
            AppSettingsHelper helper = new AppSettingsHelper(settingPath);
            return helper.GetSettings();
        }
    }
}
