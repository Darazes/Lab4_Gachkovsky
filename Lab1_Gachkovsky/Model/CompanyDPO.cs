using Lab1_Gachkovsky.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Gachkovsky.Model
{
    class CompanyDPO
    {
        public int Id { get; set; }
        public string PersonID { get; set; }
        public string OrgRegistrationID { get; set; }
        public string OrgLegFullID { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string NumberReg { get; set; }
        public DateTime DataReg { get; set; }

        public CompanyDPO() { }

        public CompanyDPO(int Id, string PersonID, string OrgRegistrationID, string OrgLegFullID,
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

        public CompanyDPO CopyFromCompany(Company company)
        {
            CompanyDPO companyDPO = new CompanyDPO();

            PersonViewModel vmPerson = new PersonViewModel();
            OrgRegistrationViewModel vmReg = new OrgRegistrationViewModel();
            OrgLegFormViewModel vmOLF = new OrgLegFormViewModel();

            string person = string.Empty;
            foreach (var p in vmPerson.ListPerson)
            {
                if (p.Id == company.PersonID)
                {
                    person = p.Shifer.ToString();
                    break;
                }
            }

            string reg = string.Empty;
            foreach (var r in vmReg.ListOrgRegistration)
            {
                if (r.Id == company.OrgRegistrationID)
                {
                    reg = r.NameFull;
                    break;
                }
            }

            string olf = string.Empty;
            foreach (var o in vmOLF.ListOrgLegForm)
            {
                if (o.Id == company.OrgLegFullID)
                {
                    olf = o.NameFull;
                    break;
                }
            }

            if (person != string.Empty)
            {
                companyDPO.Id = company.Id;
                companyDPO.PersonID = person;
                companyDPO.OrgRegistrationID = reg;
                companyDPO.OrgLegFullID = olf;
                companyDPO.NameFull = company.NameFull;
                companyDPO.NameShort = company.NameShort;
                companyDPO.NumberReg = company.NumberReg;
                companyDPO.DataReg = company.DataReg;
            }
            return companyDPO;
        }

    }
}
