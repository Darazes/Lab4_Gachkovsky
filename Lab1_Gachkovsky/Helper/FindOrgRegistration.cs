using Lab1_Gachkovsky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.Helper
{
    class FindOrgRegistration
    {
        int id;
        public FindOrgRegistration(int id)
        {
            this.id = id;
        }

        public bool OrgRegistrationPredicate(OrgRegistration or)
        {
            return or.Id == id;
        }
    }
}
