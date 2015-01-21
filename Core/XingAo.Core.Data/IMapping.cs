using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace XingAo.Core.Data
{
   [InheritedExport]
    public interface IMapping
    {
        void RegistTo(ConfigurationRegistrar configurationRegistrar);
    }
}
