using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Networks.CMS.Model.DatabaseModel;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("TemplatesGroupMapping")]
    public class TemplatesGroupMapping : MappingBase<TemplatesGroup>
    {
        public TemplatesGroupMapping()
        {
            //映射表名
            this.ToTable("XA_CMS_TemplatesGroup");
        }
    }
}
