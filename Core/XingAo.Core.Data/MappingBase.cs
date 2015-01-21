using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace XingAo.Core.Data
{
    public class MappingBase<TEntity> : EntityTypeConfiguration<TEntity>, IMapping
        where TEntity : class
    {
        public MappingBase()
        {
            this.Map(m => m.ToTable(typeof(TEntity).Name));
        }

        public void RegistTo(ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(this);
        }
    }
}