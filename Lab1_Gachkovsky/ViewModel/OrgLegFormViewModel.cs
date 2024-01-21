using Lab1_Gachkovsky.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.ViewModel
{
    class OrgLegFormViewModel
    {
        public ObservableCollection<OrgLegForm> ListOrgLegForm { get; set; } = new ObservableCollection<OrgLegForm>();

        public OrgLegFormViewModel()
        {
            ListOrgLegForm.Add(new OrgLegForm { Id = 1, NameFull = "OneLegForm", NameShort = "OLF" });
            ListOrgLegForm.Add(new OrgLegForm { Id = 2, NameFull = "TwoLegForm", NameShort = "TLF" });
            ListOrgLegForm.Add(new OrgLegForm { Id = 3, NameFull = "ThreeLegForm", NameShort = "TLF" });
        }
    }
}
