using Lab1_Gachkovsky.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.ViewModel
{
    class CompanyViewModel
    {
        public ObservableCollection<Company> ListCompany { get; set; } = new ObservableCollection<Company>();

        public CompanyViewModel()
        {
            ListCompany.Add(new Company(1, 1, 1, 1, "OneCompany","OC","1234567896958", new DateTime(1980, 02, 05)));
            ListCompany.Add(new Company(2, 2, 3, 1, "TwoCompany", "TC", "1234477893658", new DateTime(1981, 07, 12)));
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var company in this.ListCompany)
            {
                if (max < company.Id) max = company.Id;
            }
            return max;
        }
    }
}
