using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("Collect_PatternMapping")]
    public class Collect_PatternMapping : MappingBase<Collect_Pattern>
    {
        public Collect_PatternMapping()
        {
            //映射表名
            this.ToTable("XA_CMS_Collect_Pattern");
            //内外键关联
           // this.HasRequired(m => m.collect).WithMany(m => m.Collect_Patterns).HasForeignKey(c=>c.CollectId).WillCascadeOnDelete(true);
           
        }
    }
}
