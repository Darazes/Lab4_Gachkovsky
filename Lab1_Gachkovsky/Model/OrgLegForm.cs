using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.Model
{
    class OrgLegForm // Организационно - правовая форма
    {
        public int Id { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }

        public OrgLegForm() { }

        public OrgLegForm(int Id, string NameFull, string NameShort)
        {
            this.Id = Id;
            this.NameFull = NameFull;
            this.NameShort = NameShort;
        }
    }

}
