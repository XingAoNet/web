using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("AdvertisingMapping")]
    public class AdvertisingMapping : MappingBase<Advertising>
    {
        public AdvertisingMapping()
        {
            this.ToTable("XA_CMS_Advertising");
            this.HasRequired(m => m.Groups).WithMany(m => m.AdvertisingList).HasForeignKey(t => t.GroupID);
        }
    }
}
