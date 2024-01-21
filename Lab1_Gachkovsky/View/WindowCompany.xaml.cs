using Lab1_Gachkovsky.Helper;
using Lab1_Gachkovsky.Model;
using Lab1_Gachkovsky.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab1_Gachkovsky.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCompany.xaml
    /// </summary>
    public partial class WindowCompany : Window
    {
        private CompanyViewModel vmCompany = new CompanyViewModel();
        private ObservableCollection<CompanyDPO> companiesDPO;

        private PersonViewModel vmPerson;
        private ObservableCollection<Person> people;

        private OrgRegistrationViewModel vmReg;
        private ObservableCollection<OrgRegistration> regs;

        private OrgLegFormViewModel vmLeg;
        private ObservableCollection<OrgLegForm> legs;

        public WindowCompany()
        {
            InitializeComponent();
            companiesDPO = new ObservableCollection<CompanyDPO>();

            vmPerson = new PersonViewModel();
            people = vmPerson.ListPerson;

            vmReg = new OrgRegistrationViewModel();
            regs = vmReg.ListOrgRegistration;

            vmLeg = new OrgLegFormViewModel();
            legs = vmLeg.ListOrgLegForm;


            foreach (Company p in vmCompany.ListCompany)
            {
                CompanyDPO cDPO = new CompanyDPO();
                cDPO = cDPO.CopyFromCompany(p);
                companiesDPO.Add(cDPO);
            }
            ListCompany.ItemsSource = companiesDPO;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCompany windowNewCompany = new WindowNewCompany
            {
                Title = "Новое физическое лицо",
                Owner = this
            };
            int maxIdCompany = vmCompany.MaxId() + 1;

            CompanyDPO companyDPO = new CompanyDPO
            {
                Id = maxIdCompany,
                DataReg = DateTime.Now
            };

            windowNewCompany.DataContext = companyDPO;
            windowNewCompany.cb_person.ItemsSource = people;
            windowNewCompany.cb_reg.ItemsSource = regs;
            windowNewCompany.cb_leg.ItemsSource = legs;

            if (windowNewCompany.ShowDialog() == true)
            {
                Person person = (Person)windowNewCompany.cb_person.SelectedValue;
                OrgRegistration orgRegistratio = (OrgRegistration)windowNewCompany.cb_reg.SelectedValue;
                OrgLegForm orgLegForm = (OrgLegForm)windowNewCompany.cb_leg.SelectedValue;

                companyDPO.PersonID = person.Shifer.ToString();
                companyDPO.OrgRegistrationID = orgRegistratio.NameFull;
                companyDPO.OrgLegFullID = orgLegForm.NameFull;

                companiesDPO.Add(companyDPO);

                Company company = new Company();
                company = company.CopyFromCompanyDPO(companyDPO);
                vmCompany.ListCompany.Add(company);

            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
