using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{

    /// <summary>
    /// 自定义表关系
    /// </summary>
    [Export("LabelsMapping")]
    public class LabelsMapping : MappingBase<Labels>
    {
        public LabelsMapping()
        {
            //映射表名
            this.ToTable("XA_CMS_Label");
        }
    }
}
