using System;
using System.IO;
using Warehouse.Core.Domain.Repositories;
using Warehouse.Factories;
using Warehouse.Settings;

namespace Warehouse
{
    public static class ApplicationContext
    {
        private static AppSettings _defaultSettings = new AppSettings()
        {
            DbHost = "localhost",
            DbName = "master",
            DbPort = 1433,
            DbType = Core.Enums.DatabaseType.SqlServer,
            Password = "",
            UserName = "",
            WindowsAuthetication = true,
        };

        public static AppSettings Settings { get; private set; }
        public static IUnitOfWork DB { get; private set; }
        public static void Initialize()
        {
            Settings = InitializeSettings();
            DB = DbFactory.Get(Settings);
        }

        private static AppSettings InitializeSettings()
        {
            string settingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            settingPath = Path.Combine(settingPath, "Warehouse");
            AppSettingsHelper helper = new AppSettingsHelper(settingPath);

            AppSettings settings = helper.GetSettings();
            if (settings is null)
                settings = _defaultSettings;

            return settings;
        }
    }
}
