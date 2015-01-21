using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using XingAo.Networks.CMS.InterFace;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;

namespace XingAo.Networks.CMS.DbHelper
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("DefaultConnectionString")
        {
            LoadMapping();
        }

        public AppDbContext(string configKey)
            : base(configKey)
        {
            if (m_Mappings == null)
                LoadMapping();

        }

        private void LoadMapping()
        {
            DirectoryCatalog catalog;
            try
            {
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\bin"))
                    catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + @"\bin");
                else
                    catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);
            }
            catch {
                catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + @"\bin");
            }
            var container = new CompositionContainer(catalog);
            m_Mappings = container.GetExportedValues<IMapping>();
        }

        [ImportMany]
        private static IEnumerable<IMapping> m_Mappings = null;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (m_Mappings != null)
            {
                //这里是关键     
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