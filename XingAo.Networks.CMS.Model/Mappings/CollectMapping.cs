using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("CollectMapping")]
    public class CollectMapping : MappingBase<Collect>
    {
        public CollectMapping()
        {
            //映射表名
            this.ToTable("XA_CMS_Collect");
            //内外键关联
            this.HasMany(m => m.Collect_Patterns).WithRequired(c => c.collect).HasForeignKey(c => c.CollectId).WillCascadeOnDelete(true);
            this.HasMany(m => m.Collect_Patterns).WithOptional(c => c.collect);
        }
    }
}
