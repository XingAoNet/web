using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Core.Data;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("OrganizationMapping")]
    public class OrganizationMapping : MappingBase<Organization>
    {
        public OrganizationMapping()
        {
            this.ToTable("XA_Organization");
        }
    }
}
