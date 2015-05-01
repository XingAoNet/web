using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration.Configuration;
using System;

namespace XingAo.Core.Data
{
    /// <summary>
    /// 数据映射接口
    /// </summary>
    [InheritedExport]
    public interface IMapping
    {
        void RegistTo(ConfigurationRegistrar configurationRegistrar);

        Type TEntityType { get; }
        string ConnectionName { get; }
    }
}
