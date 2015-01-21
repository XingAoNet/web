using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("SystemMenuMapping")]
    public class SystemMenuMapping : MappingBase<SystemMenu>
    {
        public SystemMenuMapping()
        {
            this.ToTable("XA_CMS_SystemMenu");
            this.Ignore(a => a.Deep);
           // this.HasRequired(m => m.Menu).WithMany(m => m.ChildMenus).HasForeignKey(t => t.ParentMenuID);
        }
    }
}
