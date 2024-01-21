using Lab1_Gachkovsky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.Helper
{
    class FindCompany
    {
        int id;
        public FindCompany(int id)
        {
            this.id = id;
        }

        public bool CompanyPredicate(Company company)
        {
            return company.Id == id;
        }
    }
}
