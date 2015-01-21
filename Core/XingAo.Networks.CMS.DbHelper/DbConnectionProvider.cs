using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace XingAo.Networks.CMS.DbHelper
{
    /// <summary>
    /// 获取配置文件类型，是appSettings或connectionStrings
    /// </summary>
    enum ConfigStringType
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
                _connectionStringName = GetSetting(stringName);
                _providerName = GetProviderName(_connectionStringName);
                _connectionString = GetConnectionString(_connectionStringName);
            }

            if (type == ConfigStringType.connectionStrings)
            {
                _providerName = GetProviderName(stringName);
                _connectionString = GetConnectionString(stringName);
            }

        }

        public static string GetSetting(string NodeName)
        {
            return ConfigurationManager.AppSettings[NodeName];
        }

        private string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        private string GetProviderName(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;
        }
    }
}
