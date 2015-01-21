using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Networks.CMS.Model.DatabaseModel;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("MemberGroupsMapping")]
    public class MemberGroupsMapping : MappingBase<MemberGroups>
    {
        public MemberGroupsMapping()
        {
            //映射表名
            this.ToTable("XA_Members_Groups");
        }
    }
}
