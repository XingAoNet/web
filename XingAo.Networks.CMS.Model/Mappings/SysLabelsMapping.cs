using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{

    /// <summary>
    /// 系统标签
    /// </summary>
    [Export("SysLabelsMapping")]
    public class SysLabelsMapping : MappingBase<Model.SysLabels>
    {
        public SysLabelsMapping()
        {
            //映射表名
            this.ToTable("XA_CMS_SysLabels");
        }
    }
}
