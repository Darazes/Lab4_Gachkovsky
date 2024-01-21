using Lab1_Gachkovsky.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.Model
{
    class Company
    {
        public int Id { get; set; }
        public int PersonID { get; set; }
        public int OrgRegistrationID { get; set; }
        public int OrgLegFullID { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string NumberReg { get; set; }
        public DateTime DataReg { get; set; }

        public Company() { }

        public Company(int Id, int PersonID, int OrgRegistrationID, int OrgLegFullID,
            string NameFull, string NameShort, string NumberReg, DateTime DataReg)
        {
            this.Id = Id;
            this.PersonID = PersonID;
            this.OrgRegistrationID = OrgRegistrationID;
            this.OrgLegFullID = OrgLegFullID;
            this.NameFull = NameFull;
            this.NameShort = NameShort;
            this.NumberReg = NumberReg;
            this.DataReg = DataReg;

        }

        public Company CopyFromCompanyDPO(CompanyDPO companyDPO)
        {
            PersonViewModel vmPerson = new PersonViewModel();
            int personId = 0;

            OrgRegistrationViewModel vmReg = new OrgRegistrationViewModel();
            int regId = 0;

            OrgLegFormViewModel vmOLF = new OrgLegFormViewModel();
            int olfId = 0;

            foreach (var person in vmPerson.ListPerson)
            {
                if (person.Shifer.ToString() == companyDPO.PersonID)
                {
                    personId = person.Id;
                    break;
                }
            }

            foreach (var reg in vmReg.ListOrgRegistration)
            {
                if (reg.NameFull == companyDPO.OrgRegistrationID)
                {
                    regId = reg.Id;
                    break;
                }
            }

            foreach (var olf in vmOLF.ListOrgLegForm)
            {
                if (olf.NameFull == companyDPO.OrgLegFullID)
                {
                    olfId = olf.Id;
                    break;
                }
            }

            if (personId != 0)
            {
                this.Id = companyDPO.Id;
                this.PersonID = personId;
                this.OrgRegistrationID = regId;
                this.OrgLegFullID = olfId;
                this.NameFull = companyDPO.NameFull;
                this.NameShort = companyDPO.NameShort;
                this.NumberReg = companyDPO.NumberReg;
                this.DataReg = companyDPO.DataReg;
            }
            return this;
        }

    }
}
