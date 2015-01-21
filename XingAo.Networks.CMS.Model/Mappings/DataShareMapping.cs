using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("DataShareMapping")]
    public class DataShareMapping : MappingBase<DataShare>
    {
        public DataShareMapping()
        {
            this.ToTable("XA_CMS_DataShare");            
        }
    }
}
