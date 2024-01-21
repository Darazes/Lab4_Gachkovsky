using Lab1_Gachkovsky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.Helper
{
    class FindOrgLegForm
    {
        int id;
        public FindOrgLegForm(int id)
        {
            this.id = id;
        }

        public bool OrgLegFormPredicate(OrgLegForm olf)
        {
            return olf.Id == id;
        }
    }
}
