using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("XA_SMS_TemplatesMapping")]
    public class XA_SMS_TemplatesMapping : MappingBase<Model.XA_SMS_Templates>
    {
        public XA_SMS_TemplatesMapping()
        {
            this.ToTable("XA_SMS_Templates");
            //this.HasRequired(m => m.Groups).WithMany(m => m.AdvertisingList).HasForeignKey(t => t.GroupID);
        }
    }
}