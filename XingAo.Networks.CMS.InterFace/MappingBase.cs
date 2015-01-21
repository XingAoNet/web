using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace XingAo.Networks.CMS.InterFace
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