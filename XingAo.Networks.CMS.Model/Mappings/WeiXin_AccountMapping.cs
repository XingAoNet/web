using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;
using XingAo.Networks.CMS.Model;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("WeiXin_AccountMapping")]
    public class WeiXin_AccountMapping : MappingBase<WeiXin_Account>
    {
        public WeiXin_AccountMapping()
        {
            this.ToTable("XA_WeiXin_Account");
           
        }
    }
}
