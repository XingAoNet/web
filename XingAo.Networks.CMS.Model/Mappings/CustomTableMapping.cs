using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("CustomTableMapping")]
    public class CustomTableMapping : MappingBase<CustomTable>
    {
        public CustomTableMapping()
        {
            this.ToTable("XA_CMS_CustomTable");
        }
    }
}
