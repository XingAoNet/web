using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("Phone_MsgMapping")]
    public class Phone_MsgMapping : MappingBase<Phone_Msg>
    {
        public Phone_MsgMapping()
        {
            this.ToTable("XA_Phone_Msg");
        }
    }
}
