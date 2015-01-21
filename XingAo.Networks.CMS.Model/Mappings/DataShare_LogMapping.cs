using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("DataShare_LogMapping")]
    public class DataShare_LogMapping : MappingBase<DataShare_Log>
    {
        public DataShare_LogMapping()
        {
            this.ToTable("XA_CMS_DataShare_Log");
        }
    }
}
