using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Networks.CMS.InterFace;

namespace XingAo.Networks.CMS.Model.Mappings
{

    /// <summary>
    /// 自定义表关系
    /// </summary>
    [Export("MembersMapping")]
    public class MembersMapping : MappingBase<Members>
    {
        public MembersMapping()
        {
            //映射表名
            this.ToTable("Members");
        }
    }

}
