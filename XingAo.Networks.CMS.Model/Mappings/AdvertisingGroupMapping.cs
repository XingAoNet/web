using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("AdvertisingGroupMapping")]
    public class AdvertisingGroupMapping : MappingBase<AdvertisingGroup>
    {
        public AdvertisingGroupMapping()
        {
            this.ToTable("XA_CMS_AdvertisingGroup");
        }
    }
}
