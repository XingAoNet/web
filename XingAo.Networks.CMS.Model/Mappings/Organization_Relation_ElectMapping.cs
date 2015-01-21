using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using XingAo.Networks.CMS.InterFace;

namespace XingAo.Networks.CMS.Model.Mappings
{
    [Export("Organization_Relation_ElectMapping")]
    public class Organization_Relation_ElectMapping : MappingBase<Organization_Relation_Elect>
    {
        public Organization_Relation_ElectMapping()
        {
            this.ToTable("XA_Organization_Relation_Elect");
        }
    }
}
