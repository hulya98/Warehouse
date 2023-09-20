using Warehouse.Core.Enums;

namespace Warehouse.Settings
{
    public class AppSettings
    {
        public string DbHost { get; set; }
        public string DbPort { get; set; }
        public DatabaseType DbType { get; set; }
        public string DbName { get; set; }
        public bool WindowsAuthetication { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
