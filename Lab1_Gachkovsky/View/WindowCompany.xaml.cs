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
            WindowNewCompany windowNewCompany = new WindowNewCompany
            {
                Title = "Редактирование физического лица",
                Owner = this
            };

            CompanyDPO companyDPO = (CompanyDPO)ListCompany.SelectedValue;
            CompanyDPO tempCompanyDPO;

            if (companyDPO != null)
            {
                tempCompanyDPO = new CompanyDPO
                {
                    Id = companyDPO.Id,
                    PersonID = companyDPO.PersonID,
                    OrgRegistrationID = companyDPO.OrgRegistrationID,
                    OrgLegFullID = companyDPO.OrgLegFullID,
                    NameFull = companyDPO.NameFull,
                    NameShort = companyDPO.NameShort,
                    NumberReg = companyDPO.NumberReg,
                    DataReg = companyDPO.DataReg
                };
                windowNewCompany.DataContext = tempCompanyDPO;

                windowNewCompany.cb_person.ItemsSource = people;
                windowNewCompany.cb_person.Text = tempCompanyDPO.PersonID;

                windowNewCompany.cb_reg.ItemsSource = regs;
                windowNewCompany.cb_reg.Text = tempCompanyDPO.OrgRegistrationID;

                windowNewCompany.cb_leg.ItemsSource = legs;
                windowNewCompany.cb_leg.Text = tempCompanyDPO.OrgLegFullID;

                if (windowNewCompany.ShowDialog() == true)
                {
                    Person person = (Person)windowNewCompany.cb_person.SelectedValue;
                    OrgRegistration orgRegistratio = (OrgRegistration)windowNewCompany.cb_reg.SelectedValue;
                    OrgLegForm orgLegForm = (OrgLegForm)windowNewCompany.cb_leg.SelectedValue;

                    companyDPO.PersonID = person.Shifer.ToString(); //Проверить
                    companyDPO.OrgRegistrationID = orgRegistratio.NameFull;
                    companyDPO.OrgLegFullID = orgLegForm.NameFull;
                    companyDPO.NameFull = tempCompanyDPO.NameFull;
                    companyDPO.NameShort = tempCompanyDPO.NameShort;
                    companyDPO.NumberReg = tempCompanyDPO.NumberReg;
                    companyDPO.DataReg = tempCompanyDPO.DataReg;

                    FindCompany finder = new FindCompany(companyDPO.Id);
                    List<Company> listCompany = vmCompany.ListCompany.ToList();
                    Company company = listCompany.Find(new Predicate<Company>(finder.CompanyPredicate));
                    company = company.CopyFromCompanyDPO(companyDPO);

                    ListCompany.ItemsSource = null;
                    ListCompany.ItemsSource = companiesDPO;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать физическое лицо для редактированния ", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CompanyDPO company = (CompanyDPO)ListCompany.SelectedItem;
            if (company != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по физическому лицу: \n"
                    + company.NameFull, "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    companiesDPO.Remove(company);
                    Company companyTemp = new Company();
                    companyTemp = companyTemp.CopyFromCompanyDPO(company);
                    vmCompany.ListCompany.Remove(companyTemp);
                }
            }
            else 
            {
                MessageBox.Show("Необходимо выбрать физическое лицо для удаления ", "Предупреждение",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            };
        }
    }
}
