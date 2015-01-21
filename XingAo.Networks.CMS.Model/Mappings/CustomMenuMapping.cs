using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("CustomMenuMapping")]
    public class CustomMenuMapping : MappingBase<Model.CustomMenu>
    {
        public CustomMenuMapping()
        {
            this.ToTable("XA_WeiXin_CustomMenu");
            this.Ignore(a => a.Deep);
        }
    }
}
