using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("DataShare_ParameterConfig")]
    public class DataShare_ParameterConfig : MappingBase<Model.DataShare_ParameterConfig>
    {
        public DataShare_ParameterConfig()
        {
            this.ToTable("XA_CMS_DataShare_ParameterConfig");
            //内外键关联
            this.HasRequired(m => m.DataShareModel).WithMany(m => m.ParameterConfig).HasForeignKey(t => t.DataShareID);
        }
    }
}
