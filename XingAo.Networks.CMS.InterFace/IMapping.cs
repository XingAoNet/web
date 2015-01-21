using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace XingAo.Networks.CMS.InterFace
{
   [InheritedExport]
    public interface IMapping
    {
        void RegistTo(ConfigurationRegistrar configurationRegistrar);
    }
}
