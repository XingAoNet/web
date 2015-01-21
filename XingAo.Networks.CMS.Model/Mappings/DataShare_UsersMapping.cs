using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("DataShare_UsersMapping")]
    public class DataShare_UsersMapping : MappingBase<DataShare_Users>
    {
        public DataShare_UsersMapping()
        {
            this.ToTable("XA_CMS_DataShare_Users");
        }
    }
}
