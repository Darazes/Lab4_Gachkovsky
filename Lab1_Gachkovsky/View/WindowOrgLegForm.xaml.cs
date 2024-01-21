using Lab1_Gachkovsky.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для WindowOrgLegForm.xaml
    /// </summary>
    public partial class WindowOrgLegForm : Window
    {
        public WindowOrgLegForm()
        {
            InitializeComponent();
            OrgLegFormViewModel vmViewModel = new OrgLegFormViewModel();
            ListOrgLegForm.ItemsSource = vmViewModel.ListOrgLegForm;
        }
    }
}
