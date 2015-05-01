using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;

namespace XingAo.Core.Data
{
    public class AppDbContext : DbContext
    {
        [ImportMany]
        public static IEnumerable<IMapping> m_Mappings = null;

        public AppDbContext()
            : base("DefaultConnectionString"){}

        public AppDbContext(string configKey)
            : base(configKey)
        {
            if (m_Mappings == null)
                LoadMapping();
        }

        /// <summary>
        /// 读取系统中所有的映射信息
        /// </summary>
        private void LoadMapping()
        {
            DirectoryCatalog catalog;
            try
            {
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\bin"))
                    catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + @"\bin");
                else
                    catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);
                var container = new CompositionContainer(catalog);
                m_Mappings = container.GetExportedValues<IMapping>();
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (m_Mappings != null)
            {
                //这里是关键     
                //将映射信息逐个加载到映射缓存中
                foreach (var mapping in m_Mappings)
                {
                    mapping.RegistTo(modelBuilder.Configurations);
                }
            }
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();        
        }
    }
}