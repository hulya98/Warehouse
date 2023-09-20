using System.IO;

namespace Warehouse.Settings
{
    public class AppSettingsHelper
    {
        private readonly string _configurationPath;
        public AppSettingsHelper(string configurationPath)
        {
            _configurationPath = configurationPath;
        }

        public AppSettings ReadFromFile()
        {
            string fileName = Path.Combine(_configurationPath, "Warehouse.Settings");
            if (!File.Exists(fileName))
                return null;

            string settingsRaw = File.ReadAllText(fileName);

            AppSettings appSettings = JsonConvert
        }
    }
}
