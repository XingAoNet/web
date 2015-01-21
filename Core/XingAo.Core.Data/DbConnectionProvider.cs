
namespace XingAo.Core.Data
{
    /// <summary>
    /// 获取配置文件类型，是appSettings或connectionStrings
    /// </summary>
    public enum ConfigStringType
    {
        appSettings,
        connectionStrings
    }

    internal class DbConnectionProvider
    {
        private string _connectionString;
        private string _providerName;
        private string _connectionStringName;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public string ProviderName
        {
            get { return _providerName; }
        }


        public string ConnectionStringName
        {
            get { return _connectionStringName; }
        }

        public DbConnectionProvider(string stringName, ConfigStringType type)
        {
            if (type == ConfigStringType.appSettings)
            {
                _connectionStringName = ConfigOption.GetConfigString(stringName);
                _providerName = ConfigOption.GetProviderName(_connectionStringName);
                _connectionString = ConfigOption.GetConnectionString(_connectionStringName);
            }

            if (type == ConfigStringType.connectionStrings)
            {
                _providerName = ConfigOption.GetProviderName(stringName);
                _connectionString = ConfigOption.GetConnectionString(stringName);
            }

        }
    }
}
