using Lab1_Gachkovsky.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.ViewModel
{
    class OrgRegistrationViewModel
    {
        public ObservableCollection<OrgRegistration> ListOrgRegistration { get; set; } = new ObservableCollection<OrgRegistration>();

        public OrgRegistrationViewModel()
        {
            ListOrgRegistration.Add(new OrgRegistration { Id = 1, NameFull = "OneRegisterOrgan", NameShort = "ORO"});
            ListOrgRegistration.Add(new OrgRegistration { Id = 2, NameFull = "TwoRegisterOrgan", NameShort = "TRO" });
            ListOrgRegistration.Add(new OrgRegistration { Id = 3, NameFull = "ThreeRegisterOrgan", NameShort = "TRO" });
        }
    }
}
